SELECT b.ID, COUNT(t.TopicID) AS Numbers FROM Bookstore.Book b
	LEFT JOIN Bookstore.BookTopic t on b.ID = t.BookID
GROUP BY b.ID