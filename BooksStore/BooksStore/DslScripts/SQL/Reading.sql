Select r.ID, StatusID= lastEvent.newStatusID
From Bookstore.Reading r
OUTER APPLY(
	Select Top 1 *
	from Bookstore.ReadingEvent re
	where re.ReadingID = r.ID
	ORDER BY re.ExecuteDate
) lastEvent