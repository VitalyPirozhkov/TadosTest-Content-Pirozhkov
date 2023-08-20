SELECT c.id AS ContentId,
       COALESCE(AVG(r.Value), 0) AS AverageRating
FROM Content c
LEFT JOIN Rating r ON c.id = r.ContentId
WHERE c.type = 2 -- 2 corresponds to Video type
GROUP BY c.id;
