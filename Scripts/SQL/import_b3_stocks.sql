USE tradescope;

SET NOCOUNT ON;

BEGIN TRY
    BEGIN TRAN;

    DECLARE @JsonPath NVARCHAR(4000) = N'E:\Git\Ativos\b3.json'; -- ajuste
    DECLARE @sql NVARCHAR(MAX);
    DECLARE @json NVARCHAR(MAX);

    -- 1) Ler o arquivo (via SQL dinâmico)
    SET @sql = N'
        SELECT @json_out = BulkColumn
        FROM OPENROWSET(BULK ''' + REPLACE(@JsonPath,'''','''''') + N''', SINGLE_CLOB) AS j;
    ';

    EXEC sys.sp_executesql
        @sql,
        N'@json_out NVARCHAR(MAX) OUTPUT',
        @json_out = @json OUTPUT;

    -- 2) Inserir SOMENTE $.stocks nas colunas pedidas
    INSERT INTO dbo.tbl_b3_stocks (stock, name, logo, sector, type)
    SELECT
        s.stock,
        s.name,
        COALESCE(s.logo,   'https://icons.brapi.dev/icons/BRAPI.svg') AS logo,
        COALESCE(s.sector, 'Unknown')                                 AS sector,
        COALESCE(s.[type], 'stock')                                   AS [type]
    FROM OPENJSON(@json, '$.stocks')
    WITH (
        stock  VARCHAR(10)  '$.stock',
        name   VARCHAR(255) '$.name',
        logo   VARCHAR(255) '$.logo',
        sector VARCHAR(50)  '$.sector',
        [type] VARCHAR(20)  '$.type'
    ) AS s;

    COMMIT;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK;
    THROW;
END CATCH;
