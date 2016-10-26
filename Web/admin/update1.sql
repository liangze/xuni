create procedure [dbo].[proc_fudao]
@UserID INT
as

DECLARE @sid INT, --子会员ID
		@sregmoney NUMERIC(18,2), --子会员注册资金
		@jiandianrate NUMERIC(18,2), --见点比率
		@jdmoney NUMERIC(18,2), --见点奖
		@sum NUMERIC(18,2),
		@pid INT,
		@maxlayer INT,
		@typeid INT,
		@layer INT,
		@remark VARCHAR(500),
		@remarken VARCHAR(500),
		@jstime DATETIME
SET @maxlayer=10
SET @jiandianrate=2.00
SET @sum=0.00
SET @jstime=GETDATE()
SET @typeid=5
SELECT TOP 1 @layer= Layer  FROM tb_user WHERE UserID =@userid
SELECT UserID INTO #tmp_fdj FROM tb_user WHERE Layer>@layer and Layer<(@layer+@maxlayer+1) and UserPath like '%'+CAST(@userid as varchar(50))+'%'
WHILE EXISTS (SELECT * FROM #tmp_fdj)
BEGIN
	SELECT TOP 1 @sid = UserID FROM #tmp_fdj
	SELECT @sregmoney=RegMoney FROM dbo.tb_user WHERE UserID=@sid
	SET @jdmoney=@sregmoney*(@jiandianrate/100)
	SET @sum=@sum+@jdmoney
	DELETE FROM #tmp_fdj WHERE UserID=@sid
END
SET @remark='获得辅导奖'+CAST(@sum AS VARCHAR(50))
SET @remarken='get fudaoaward'+CAST(@sum AS VARCHAR(50))

EXEC proc_bonus @UserID,@sum,@typeid,0,@UserID,1,@remark,@remarkEn,@jstime