SELECT     [Equibrand Products Group$Customer].No_, [Equibrand Products Group$Customer].Name, [Equibrand Products Group$Customer].City, 
                      [Equibrand Products Group$Customer].Contact, [Equibrand Products Group$Customer].[Phone No_], 
                      [Equibrand Products Group$Customer].[Territory Code], [Equibrand Products Group$Customer].[Salesperson Code], 
                      [Equibrand Products Group$Customer].[On Hold], SUM(CASE WHEN (2000 + [AcctYear] = Year(GetDate())) THEN TDWSalesHist.Amount ELSE 0 END) 
                      AS YTD, SUM(CASE WHEN (2000 + [AcctYear] = Year(GetDate()) - 1 AND TDWSalesHist.[Shipment Date] < DateAdd([yyyy], - 1, GetDate())) 
                      THEN TDWSalesHist.Amount ELSE 0 END) AS LYTD, SUM(CASE WHEN (2000 + [AcctYear] = Year(GetDate()) - 1) 
                      THEN TDWSalesHist.Amount ELSE 0 END) AS LY, SUM(CASE WHEN TDWSalesHist.[Shipment Date] BETWEEN @PeriodStart AND 
                      @PeriodEnd THEN TDWSalesHist.Amount ELSE 0 END) AS Period, SUM(CASE WHEN TDWSalesHist.[Shipment Date] BETWEEN DateAdd([yyyy], - 1, 
                      @PeriodStart) AND DateAdd([yyyy], - 1, @PeriodEnd) THEN TDWSalesHist.Amount ELSE 0 END) AS LYPeriod, 
                      [Equibrand Products Group$Customer].[Cust Service Rep], L.OpenSo, [Equibrand Products Group$Customer].[Main Shipto State]
FROM         [Equibrand Products Group$Customer] INNER JOIN
                      TWSalesHist AS TDWSalesHist ON [Equibrand Products Group$Customer].No_ = TDWSalesHist.[Sell-to Customer No_] LEFT OUTER JOIN
                          (SELECT     [Sell-to Customer No_], SUM([Outstanding Amount]) AS OpenSo
                            FROM          [Equibrand Products Group$Sales Line]
                            WHERE      ([Document Type] = 1)
                            GROUP BY [Sell-to Customer No_]) AS L ON [Equibrand Products Group$Customer].No_ = L.[Sell-to Customer No_]
WHERE     ([Equibrand Products Group$Customer].[Territory Code] LIKE LTRIM(COALESCE (@Territory, ' ') + '%')) AND 
                      ([Equibrand Products Group$Customer].[Salesperson Code] LIKE LTRIM(COALESCE (@Salesperson, ' ') + '%')) AND 
                      ([Equibrand Products Group$Customer].[Cust Service Rep] LIKE LTRIM(COALESCE (@CustServRep, ' ') + '%')) AND 
                      (NOT (TDWSalesHist.[Posting Group] = 'EEQUINE')) AND 
                      ([Equibrand Products Group$Customer].[Main Shipto State] LIKE LTRIM(COALESCE (@ShipToState, ' ') + '%'))
GROUP BY [Equibrand Products Group$Customer].No_, [Equibrand Products Group$Customer].Name, [Equibrand Products Group$Customer].City, 
                      [Equibrand Products Group$Customer].Contact, [Equibrand Products Group$Customer].[Phone No_], 
                      [Equibrand Products Group$Customer].[Territory Code], [Equibrand Products Group$Customer].[Salesperson Code], 
                      [Equibrand Products Group$Customer].[On Hold], [Equibrand Products Group$Customer].[Cust Service Rep], L.OpenSo, 
                      [Equibrand Products Group$Customer].[Main Shipto State]
ORDER BY [Equibrand Products Group$Customer].[Territory Code], [Equibrand Products Group$Customer].[Main Shipto State]