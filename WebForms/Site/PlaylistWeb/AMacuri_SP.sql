
-- EXEC dbo.GetTracksByPlaylist 6;
ALTER PROCEDURE dbo.GetTracksByPlaylist
@PI_PlaylistId	INT
AS
BEGIN
	SELECT
		T0.PlaylistId
		,T0.TrackId
		,T1.Name
		,T1.Composer
		,[Duration] = T1.Milliseconds / 6000
	FROM [dbo].[PlaylistTrack] T0
		INNER JOIN [dbo].[Track] T1 ON (T0.TrackId = T1.TrackId)
	WHERE
		T1.MediaTypeId = 1
		AND T0.PlaylistId = @PI_PlaylistId
	ORDER BY T1.Name
	;
END


