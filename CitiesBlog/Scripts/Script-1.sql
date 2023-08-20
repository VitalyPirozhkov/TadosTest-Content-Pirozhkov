SELECT u.login AS Username,
       u.id AS UserId,
       COALESCE(AVG(r.Value), 0) AS UserAverageRating
FROM user u
LEFT JOIN Content c ON u.id = c.CreatorId
LEFT JOIN Rating r ON c.id = r.ContentId
GROUP BY u.id
ORDER BY UserAverageRating DESC;
