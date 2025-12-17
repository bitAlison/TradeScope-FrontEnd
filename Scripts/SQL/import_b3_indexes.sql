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

    -- 2) Inserir SOMENTE $.indexes (stock, name)
    INSERT INTO dbo.tbl_indexes (stock, name)
    SELECT
        i.stock,
        i.name
    FROM OPENJSON(@json, '$.indexes')
    WITH (
        stock VARCHAR(50)  '$.stock',
        name  VARCHAR(255) '$.name'
    ) AS i;

    COMMIT;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK;
    THROW;
END CATCH;
