create procedure [dbo].[proc_xingyun]
@UserID INT
as

DECLARE @sid INT,
		@ssid INT, --孙子会员ID
		@sregmoney NUMERIC(18,2), --子会员注册资金
		@jiandianrate NUMERIC(18,2), --见点比率
		@jdmoney NUMERIC(18,2), --见点奖
		@sum NUMERIC(18,2), --子会员获得的十层见点奖
		@totalsum NUMERIC(18,2), --会员获得子会员的总见点奖
		@maxlayer INT, --获得多少层的见点
		@typeid INT,
		@layer INT,
		@remark VARCHAR(500),
		@remarken VARCHAR(500),
		@opentime DATETIME,
		@jstime DATETIME
SET @maxlayer=10
SET @jiandianrate=2.00
SET @sum=0.00
SET @totalsum=0.00
SET @jstime=GETDATE()
SET @typeid=6

CREATE TABLE #tmp_aaa(
	UserID BIGINT
)

SELECT @opentime=OpenTime FROM dbo.tb_user WHERE UserID=@UserID --获得会员的开通时间
SELECT TOP 10 UserID INTO #tmp_sid FROM dbo.tb_user WHERE OpenTime>@opentime AND IsOpend=2 ORDER BY OpenTime --获得后十位开通会员ID并放入临时表#tmp_sid
WHILE EXISTS(SELECT * FROM #tmp_sid)
BEGIN
	SELECT TOP 1 @sid=UserID FROM #tmp_sid  --获得一个子会员的ID
	SELECT TOP 1 @layer= Layer  FROM tb_user WHERE UserID =@sid --子会员所在层
	INSERT INTO #tmp_aaa
	SELECT UserID  FROM tb_user WHERE Layer>@layer and Layer<(@layer+@maxlayer+1) and UserPath like '%'+CAST(@sid as varchar(50))+'%' --取后十层会员ID并放入临时表#tmp_xyj
	WHILE EXISTS (SELECT * FROM #tmp_aaa)
	BEGIN
		SELECT TOP 1 @ssid = UserID FROM #tmp_aaa 
		SELECT @sregmoney=RegMoney FROM dbo.tb_user WHERE UserID=@ssid
		SET @jdmoney=@sregmoney*(@jiandianrate/100)
		SET @sum=@sum+@jdmoney
		DELETE FROM #tmp_aaa WHERE UserID=@ssid
	END
	DELETE FROM #tmp_sid WHERE USERID=@sid
END
SET @remark='获得幸运奖'+CAST(@totalsum AS VARCHAR(50))
SET @remarken='get fudaoaward'+CAST(@totalsum AS VARCHAR(50))
EXEC proc_bonus @UserID,@sum,@typeid,0,@UserID,1,@remark,@remarkEn,@jstime