SELECT c.id AS ContentId, 
       COALESCE(AVG(r.Value), 0) AS AverageRating
FROM Content c
LEFT JOIN Rating r ON c.id = r.ContentId
GROUP BY c.id
ORDER BY AverageRating DESC;
