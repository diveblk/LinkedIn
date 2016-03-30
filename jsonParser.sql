Select a.[User] + ':' + a.[Status] + ':' + a.Number as 'result' from (

SELECT REPLACE([User ID], 'CLASSIC\','') as 'User', CASE WHEN [On Hold] = '' THEN 'Open' Else 'On Hold' END as 'Status', No_ AS 'Number', REPLACE([No_], '"', '') AS 'No_'
FROM [Equibrand Products Group$Sales Header]
WHERE cast ([Posting Date] as DATE) BETWEEN DATEADD(dd, -(DATEPART(dw, GETDATE())), GETDATE()-7) AND GETDATE()
AND [No_] like '%OR%'
AND No_ <> '461000'
AND No_ <> ''


) a
ORDER BY a.[User], a.[Status], a.Number, a.No_