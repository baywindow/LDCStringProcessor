SELECT Bs.Business, ISNULL(Pm.StreetNo, '') AS StreetNo, Pm.Street, Pm.PostCode, SUM(Ff.Count) AS FootfallCount
  FROM Businesses AS Bs WITH (NOLOCK)
	LEFT JOIN
		Premises AS Pm WITH (NOLOCK) ON Bs.Id = Pm.BusinessId
	LEFT JOIN
		Footfall AS Ff WITH (NOLOCK) ON Pm.Id = Ff.PremisesId
	GROUP BY
		Bs.Business, Pm.StreetNo, Pm.Street, Pm.PostCode
