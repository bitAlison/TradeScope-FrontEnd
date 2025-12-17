USE tradescope;
SET NOCOUNT ON;

BEGIN TRY
    BEGIN TRAN;

    DECLARE @JsonPath NVARCHAR(4000) = N'E:\Git\Ativos\commodities.json'; -- ajuste
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

    -- 2) Inserir SOMENTE $.indexes (stock, name)
    INSERT INTO dbo.tbl_commodities (symbol, name)
    SELECT
        i.symbol,
        i.name
    FROM OPENJSON(@json, '$.commodities')
    WITH (
        symbol VARCHAR(10)  '$.symbol',
        name  VARCHAR(255) '$.name'
    ) AS i;

    COMMIT;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK;
    THROW;
END CATCH;
