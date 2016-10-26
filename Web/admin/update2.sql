ALTER procedure [dbo].[proc_guanlijiang]
@UserID INT ---用户ID

AS
DECLARE @firstrid INT, --第一代推荐人ID
		@secondrid INT, --第二代推荐人ID
		@count INT
SET @count=0
DECLARE firstid CURSOR
FOR SELECT UserID FROM dbo.tb_user WHERE RecommendID=@UserID AND IsOpend=2
OPEN firstid
FETCH NEXT FROM firstid INTO @firstrid
WHILE @@FETCH_STATUS=0
	BEGIN
		DECLARE secondid CURSOR
		FOR SELECT UserID FROM dbo.tb_user WHERE RecommendID=@firstrid AND IsOpend=2
		OPEN secondid
		FETCH NEXT FROM secondid INTO @secondrid

		WHILE @@FETCH_STATUS=0
			BEGIN
				IF (@secondrid>0)
					BEGIN
						EXEC proc_guanlijiang2 @secondrid
					END
				FETCH NEXT FROM secondid INTO @secondrid
			END
		CLOSE secondid
		DEALLOCATE secondid
	--EXEC dbo.proc_duipeng @userID
		IF (@firstrid>0)
			BEGIN
				EXEC proc_guanlijiang2 @firstrid
				SET @count=@count+1
				IF (@count=3)
				BEGIN
					EXEC proc_fudao @UserID
				END
			END
	FETCH NEXT FROM firstid INTO @firstrid
	END
CLOSE firstid
DEALLOCATE firstid