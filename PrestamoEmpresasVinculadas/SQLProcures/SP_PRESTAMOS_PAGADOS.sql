CREATE OR ALTER PROCEDURE [dbo].[SP_PRESTAMOS_PAGADOS] @MONEDA NVARCHAR(100), @EMPRESA_ACREEDORA NVARCHAR(200), @EMPRESA_DEUDORA NVARCHAR(200)
AS
BEGIN

	--WITH CTE_DEVOLUCION AS(	
	--	SELECT T1.U_GMI_PAGORELACION NroPrestamo,
	--			T0.DocCurr,
	--			SUM(IIF(T0.DoccuRr = 'SOL', T1.SumApplied, IIF(T0.DoccuRr = 'USD', T1.AppliedFC, 0.00))) Acumulado
	--	FROM [JUPITER].[Z_SBO_RUMI_25072025_2].DBO.ORCT T0 LEFT JOIN [JUPITER].[Z_SBO_RUMI_25072025_2].DBO.RCT4 T1 ON T0.DOCENTRY = T1.DOCNUM
	--	WHERE CAST(DOCDATE AS DATE) >= '2025-08-18' AND T1.AcctCode = '471003'
	--		AND T0.DocType = 'A' AND T0.Canceled = 'N'
	--	GROUP BY T1.U_GMI_PAGORELACION, T0.DocCurr
	--)

	--SELECT 
	--	DocEntry, 
	--	DocNum 'Nro Prestamo', 
	--	[Fecha Prestamo], 
	--	[Comentario Prestamo], 
	--	Moneda, 
	--	[Cuenta Banco],
	--	CAST(MontoPrestamo AS DECIMAL(16,2)) MontoPrestamo, 
	--	CAST((MontoPrestamo - Acumulado) AS DECIMAL(16,2)) Saldo
	--FROM (
	--	SELECT T0.DocEntry, 
	--		   T0.DocNum, 
	--		   CAST(T0.DocDate AS DATE) 'Fecha Prestamo', 
	--		   ISNULL(T0.Comments, '') 'Comentario Prestamo', 
	--		   T0.DocCurr 'Moneda',
	--		   T0.TrsfrAcct 'Cuenta Banco', 
	--		   IIF(T0.DoccuRr = 'SOL', T1.SumApplied, IIF(T0.DoccuRr = 'USD', T1.AppliedFC, 0.00)) MontoPrestamo,
	--		   ISNULL(T2.Acumulado, 0.00) Acumulado
	--	FROM [JUPITER].[Z_SBO_RUMI_25072025_2].DBO.OVPM T0 LEFT JOIN [JUPITER].[Z_SBO_RUMI_25072025_2].DBO.VPM4 T1 ON T0.DocEntry = T1.DocNum
	--		 LEFT JOIN CTE_DEVOLUCION T2 ON T0.DocNum = T2.NroPrestamo AND T0.DocCurr = T2.DocCurr
	--	WHERE CAST(T0.DOCDATE AS DATE) >= '2025-08-18' AND T1.AcctCode = '171201'
	--		AND T0.DocType = 'A' AND T0.Canceled = 'N'
	--)XTABLE
	--WHERE (MontoPrestamo - Acumulado) = 0.00
	--ORDER BY DocNum ASC


	DECLARE @CONSULTA NVARCHAR(MAX) = '
	WITH CTE_DEVOLUCION AS(	
		SELECT T1.U_GMI_PAGORELACION NroPrestamo,
				T0.DocCurr,
				SUM(IIF(T0.DoccuRr = ''SOL'', T1.SumApplied, IIF(T0.DoccuRr = ''USD'', T1.AppliedFC, 0.00))) Acumulado
		FROM ' + @EMPRESA_ACREEDORA + '.DBO.ORCT T0 LEFT JOIN ' + @EMPRESA_ACREEDORA + '.DBO.RCT4 T1 ON T0.DOCENTRY = T1.DOCNUM
		WHERE CAST(DOCDATE AS DATE) >= ''2025-08-18'' AND T1.AcctCode = ''171201''
			AND T0.DocType = ''A'' AND T0.Canceled = ''N''
			AND T0.DoccuRr = ''' + @MONEDA + '''
		GROUP BY T1.U_GMI_PAGORELACION, T0.DocCurr
	)

	SELECT 
		DocEntry, [Nro Prestamo], [Fecha Prestamo], [Comentario Prestamo], Moneda, [Cuenta Banco], CAST(MontoPrestamo AS DECIMAL(16,2)) MontoPrestamo, CAST((MontoPrestamo - Acumulado) AS DECIMAL(16,2)) Saldo
	FROM (
		SELECT T0.DocEntry, 
			   T0.DocNum ''Nro Prestamo'', 
			   CAST(T0.DocDate AS DATE) ''Fecha Prestamo'', 
			   ISNULL(T0.Comments, '''') ''Comentario Prestamo'', 
			   T0.DocCurr ''Moneda'', 
			   T0.TrsfrAcct ''Cuenta Banco'',
			   IIF(T0.DoccuRr = ''SOL'', T1.SumApplied, IIF(T0.DoccuRr = ''USD'', T1.AppliedFC, 0.00)) MontoPrestamo,
			   ISNULL(T2.Acumulado, 0.00) Acumulado
		FROM ' + @EMPRESA_ACREEDORA + '.DBO.OVPM T0 LEFT JOIN ' + @EMPRESA_ACREEDORA + '.DBO.VPM4 T1 ON T0.DocEntry = T1.DocNum
			 LEFT JOIN CTE_DEVOLUCION T2 ON T0.DocNum = T2.NroPrestamo AND T0.DocCurr = T2.DocCurr
		WHERE CAST(T0.DOCDATE AS DATE) >= ''2025-08-18'' AND T1.AcctCode = ''171201''
			AND T0.DocType = ''A'' AND T0.Canceled = ''N''
			AND T0.DoccuRr = ''' + @MONEDA + '''
	)XTABLE
	where (MontoPrestamo - Acumulado) = 0.00 AND [Nro Prestamo] NOT IN (SELECT NRO_PRESTAMO FROM LOG_RECONCILIACION)
	ORDER BY [Nro Prestamo] ASC'

	EXECUTE(@CONSULTA)


END