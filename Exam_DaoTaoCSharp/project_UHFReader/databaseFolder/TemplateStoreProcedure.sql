--Insert, update, delete, select
--selectALL, SelectByID -121000123
CREATE PROC PSP_GhiChu_Select
    @MaSinhVien VARCHAR(9) = '0'
AS
    SELECT  MaSinhVien ,
            MaGhiChu ,
            NoiDung ,
            NgayTao ,
            MaGiaoVien
    FROM    dbo.GhiChu
    WHERE   @MaSinhVien = CASE @MaSinhVien
                            WHEN '0' THEN '0'
                            ELSE MaSinhVien
                          END;
                          GO
   --INSERT  , update  
CREATE PROC PSP_GhiChu_InsertAndUpdate
    @MaSinhVien VARCHAR(9) ,
    @MaGhiChu INT ,
    @NoiDung NTEXT ,
    @NgayTao DATE ,
    @MaGiaoVien VARCHAR(9)
AS
    IF EXISTS ( SELECT  1
                FROM    dbo.GhiChu
                WHERE   MaSinhVien = @MaSinhVien
                        AND MaGhiChu = @MaGhiChu )
        BEGIN
            UPDATE  dbo.GhiChu
            SET     NoiDung = @NoiDung ,
                    NgayTao = @NgayTao ,
                    MaGiaoVien = @MaGiaoVien
            WHERE   MaSinhVien = @MaSinhVien
                    AND MaGhiChu = @MaGhiChu;
        END;
    ELSE
        BEGIN
            INSERT  INTO GhiChu
                    ( MaSinhVien ,
                      MaGhiChu ,
                      NoiDung ,
                      NgayTao ,
                      MaGiaoVien
                    )
            VALUES  ( @MaSinhVien ,
                      @MaGhiChu ,
                      @NoiDung ,
                      @NgayTao ,
                      @MaGiaoVien
                    );
        END;
        GO
  --Delete ghi vu
CREATE PROC PSP_GhiChu_Delete
    @MaSinhVien VARCHAR(9) ,
    @MaGhiChu INT
AS
    DELETE  dbo.GhiChu
    WHERE   MaSinhVien = @MaSinhVien
            AND MaGhiChu = @MaGhiChu;
 --delete Chuc Vu
 go
 CREATE PROC PSP_ChucVu_Delete
 @MaChucVu int
 AS
 UPDATE dbo.ChucVu
 SET IsDelete=1
 WHERE MaChucVu=@MaChucVu