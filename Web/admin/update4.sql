ALTER procedure [dbo].[proc_userbonus]
AS
DECLARE @UserID BIGINT
DECLARE recoID CURSOR
FOR SELECT UserID FROM dbo.tb_user WHERE IsOpend=2
OPEN recoID
FETCH NEXT FROM recoID INTO @UserID

WHILE @@FETCH_STATUS=0 
	BEGIN
	    --EXEC dbo.proc_TEST_JS_RongYu @userID
	    EXEC dbo.proc_guanlijiang @UserID
	    EXEC dbo.proc_xingyun @UserID
		FETCH NEXT FROM recoID INTO @UserID
	END
CLOSE recoID
DEALLOCATE recoID