
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/07/2017 18:19:08
-- Generated from EDMX file: E:\Capstone\iercapstone\Source-Codes\IERSystem\IERSystem\Areas\Administrator\Models\IERSystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IERSystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PhieuYeuCau_MauLayHienTruong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MauLayHienTruongs] DROP CONSTRAINT [FK_PhieuYeuCau_MauLayHienTruong];
GO
IF OBJECT_ID(N'[dbo].[FK_MauLayHienTruong_ChiTieuPhanTich_MauLayHienTruong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MauLayHienTruong_ChiTieuPhanTich] DROP CONSTRAINT [FK_MauLayHienTruong_ChiTieuPhanTich_MauLayHienTruong];
GO
IF OBJECT_ID(N'[dbo].[FK_MauLayHienTruong_ChiTieuPhanTich_ChiTieuPhanTich]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MauLayHienTruong_ChiTieuPhanTich] DROP CONSTRAINT [FK_MauLayHienTruong_ChiTieuPhanTich_ChiTieuPhanTich];
GO
IF OBJECT_ID(N'[dbo].[FK_CacSoNhanMau_SoNhanMau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoNhanMaus] DROP CONSTRAINT [FK_CacSoNhanMau_SoNhanMau];
GO
IF OBJECT_ID(N'[dbo].[FK_MauLayHienTruong_SoNhanMau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoNhanMaus] DROP CONSTRAINT [FK_MauLayHienTruong_SoNhanMau];
GO
IF OBJECT_ID(N'[dbo].[FK_CacSoChuyenMauSoChuyenMau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoChuyenMaus] DROP CONSTRAINT [FK_CacSoChuyenMauSoChuyenMau];
GO
IF OBJECT_ID(N'[dbo].[FK_SoKQThuNghiemKQThuNghiemMau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KQThuNghiemMaus] DROP CONSTRAINT [FK_SoKQThuNghiemKQThuNghiemMau];
GO
IF OBJECT_ID(N'[dbo].[FK_MauLayHienTruong_SoChuyenMau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoChuyenMaus] DROP CONSTRAINT [FK_MauLayHienTruong_SoChuyenMau];
GO
IF OBJECT_ID(N'[dbo].[FK_FormKQ_KQPhanTichFormKQ]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KQPhanTichFormKQs] DROP CONSTRAINT [FK_FormKQ_KQPhanTichFormKQ];
GO
IF OBJECT_ID(N'[dbo].[FK_SoChuyenMau_ChiTieuPhanTich_SoChuyenMau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoChuyenMau_ChiTieuPhanTich] DROP CONSTRAINT [FK_SoChuyenMau_ChiTieuPhanTich_SoChuyenMau];
GO
IF OBJECT_ID(N'[dbo].[FK_SoChuyenMau_ChiTieuPhanTich_ChiTieuPhanTich]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoChuyenMau_ChiTieuPhanTich] DROP CONSTRAINT [FK_SoChuyenMau_ChiTieuPhanTich_ChiTieuPhanTich];
GO
IF OBJECT_ID(N'[dbo].[FK_KQThuNghiemMau_ChiTieuPhanTich_KQThuNghiemMau]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KQThuNghiemMau_ChiTieuPhanTich] DROP CONSTRAINT [FK_KQThuNghiemMau_ChiTieuPhanTich_KQThuNghiemMau];
GO
IF OBJECT_ID(N'[dbo].[FK_KQThuNghiemMau_ChiTieuPhanTich_ChiTieuPhanTich]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KQThuNghiemMau_ChiTieuPhanTich] DROP CONSTRAINT [FK_KQThuNghiemMau_ChiTieuPhanTich_ChiTieuPhanTich];
GO
IF OBJECT_ID(N'[dbo].[FK_SoKQThuNghiem_MauLayHienTruong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoKQThuNghiems] DROP CONSTRAINT [FK_SoKQThuNghiem_MauLayHienTruong];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PhieuYeuCaus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhieuYeuCaus];
GO
IF OBJECT_ID(N'[dbo].[MauLayHienTruongs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MauLayHienTruongs];
GO
IF OBJECT_ID(N'[dbo].[ChiTieuPhanTiches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTieuPhanTiches];
GO
IF OBJECT_ID(N'[dbo].[SoNhanMaus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoNhanMaus];
GO
IF OBJECT_ID(N'[dbo].[CacSoNhanMaus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CacSoNhanMaus];
GO
IF OBJECT_ID(N'[dbo].[SoChuyenMaus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoChuyenMaus];
GO
IF OBJECT_ID(N'[dbo].[CacSoChuyenMaus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CacSoChuyenMaus];
GO
IF OBJECT_ID(N'[dbo].[KQThuNghiemMaus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KQThuNghiemMaus];
GO
IF OBJECT_ID(N'[dbo].[SoKQThuNghiems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoKQThuNghiems];
GO
IF OBJECT_ID(N'[dbo].[FormKQs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormKQs];
GO
IF OBJECT_ID(N'[dbo].[KQPhanTichFormKQs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KQPhanTichFormKQs];
GO
IF OBJECT_ID(N'[dbo].[MauLayHienTruong_ChiTieuPhanTich]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MauLayHienTruong_ChiTieuPhanTich];
GO
IF OBJECT_ID(N'[dbo].[SoChuyenMau_ChiTieuPhanTich]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoChuyenMau_ChiTieuPhanTich];
GO
IF OBJECT_ID(N'[dbo].[KQThuNghiemMau_ChiTieuPhanTich]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KQThuNghiemMau_ChiTieuPhanTich];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PhieuYeuCaus'
CREATE TABLE [dbo].[PhieuYeuCaus] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DiaChiKhachHang] nvarchar(max)  NULL,
    [DiaChiLayMau] nvarchar(max)  NOT NULL,
    [KhachHangTraTruoc] decimal(18,0)  NULL,
    [MaDon] nvarchar(max)  NOT NULL,
    [MaSoThue] nvarchar(max)  NULL,
    [NgayTaoHD] datetime  NOT NULL,
    [NoiLayMau] nvarchar(max)  NOT NULL,
    [PhiThiNghiemTamTinh] decimal(18,0)  NULL,
    [SoDienThoai] nvarchar(max)  NULL,
    [SoFax] nvarchar(max)  NULL,
    [TenDaiDien] nvarchar(max)  NULL,
    [TenKhachHang] nvarchar(max)  NULL,
    [NgayLayMau] datetime  NOT NULL,
    [NgayHenTraKQ] datetime  NOT NULL
);
GO

-- Creating table 'MauLayHienTruongs'
CREATE TABLE [dbo].[MauLayHienTruongs] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [MaMau] nvarchar(max)  NULL,
    [MaMauKH] nvarchar(max)  NULL,
    [DonVi] nvarchar(max)  NOT NULL,
    [MoTaMau] nvarchar(max)  NOT NULL,
    [SoLuong] int  NOT NULL,
    [ViTriLayMau] nvarchar(max)  NOT NULL,
    [PhieuYeuCauId] bigint  NOT NULL,
    [TinhTrang] tinyint  NOT NULL
);
GO

-- Creating table 'ChiTieuPhanTiches'
CREATE TABLE [dbo].[ChiTieuPhanTiches] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TenChiTieu] nvarchar(max)  NOT NULL,
    [ChiPhi] decimal(18,0)  NOT NULL,
    [TenPhuongPhap] nvarchar(max)  NOT NULL,
    [NhomChiTieuId] bigint  NOT NULL
);
GO

-- Creating table 'SoNhanMaus'
CREATE TABLE [dbo].[SoNhanMaus] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [KHKiNhanTraKQ] bit  NOT NULL,
    [KHKiNhanTraTien] bit  NOT NULL,
    [NgayNhan] datetime  NOT NULL,
    [NgayTraKQ] datetime  NOT NULL,
    [CacSoNhanMauId] bigint  NOT NULL,
    [MauLayHienTruong_Id] bigint  NOT NULL
);
GO

-- Creating table 'CacSoNhanMaus'
CREATE TABLE [dbo].[CacSoNhanMaus] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TuNgay] datetime  NOT NULL,
    [DenNgay] datetime  NOT NULL
);
GO

-- Creating table 'SoChuyenMaus'
CREATE TABLE [dbo].[SoChuyenMaus] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DienTen] nvarchar(max)  NULL,
    [GhiChu] nvarchar(max)  NULL,
    [NgayGiaoMau] datetime  NOT NULL,
    [NgayTraKQ] datetime  NOT NULL,
    [CacSoChuyenMauId] bigint  NOT NULL,
    [MauLayHienTruong_Id] bigint  NOT NULL
);
GO

-- Creating table 'CacSoChuyenMaus'
CREATE TABLE [dbo].[CacSoChuyenMaus] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TuNgay] datetime  NOT NULL,
    [DenNgay] datetime  NOT NULL
);
GO

-- Creating table 'KQThuNghiemMaus'
CREATE TABLE [dbo].[KQThuNghiemMaus] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DonVi] nvarchar(max)  NOT NULL,
    [KetQua] nvarchar(max)  NOT NULL,
    [NguoiThucHien] nvarchar(max)  NOT NULL,
    [SoKQThuNghiemId] bigint  NOT NULL
);
GO

-- Creating table 'SoKQThuNghiems'
CREATE TABLE [dbo].[SoKQThuNghiems] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [MaMau] nvarchar(max)  NOT NULL,
    [NgayNhanMau] datetime  NOT NULL,
    [NgayTraMau] datetime  NOT NULL,
    [MauLayHienTruong_Id] bigint  NOT NULL
);
GO

-- Creating table 'FormKQs'
CREATE TABLE [dbo].[FormKQs] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [NoiLayMau] nvarchar(max)  NOT NULL,
    [DiaChi] nvarchar(max)  NOT NULL,
    [ViTriLayMau] nvarchar(max)  NOT NULL,
    [NgayGuiMau] datetime  NOT NULL,
    [LoaiMau] nvarchar(max)  NOT NULL,
    [MaDon] nvarchar(max)  NOT NULL,
    [MaMau] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KQPhanTichFormKQs'
CREATE TABLE [dbo].[KQPhanTichFormKQs] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DonVi] nvarchar(max)  NOT NULL,
    [GiaTri] nvarchar(max)  NOT NULL,
    [FormKQId] bigint  NOT NULL
);
GO

-- Creating table 'NhomChiTieux'
CREATE TABLE [dbo].[NhomChiTieux] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TenNhom] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MauLayHienTruong_ChiTieuPhanTich'
CREATE TABLE [dbo].[MauLayHienTruong_ChiTieuPhanTich] (
    [MauLayHienTruongs_Id] bigint  NOT NULL,
    [ChiTieuPhanTiches_Id] bigint  NOT NULL
);
GO

-- Creating table 'SoChuyenMau_ChiTieuPhanTich'
CREATE TABLE [dbo].[SoChuyenMau_ChiTieuPhanTich] (
    [SoChuyenMaus_Id] bigint  NOT NULL,
    [ChiTieuPhanTiches_Id] bigint  NOT NULL
);
GO

-- Creating table 'KQThuNghiemMau_ChiTieuPhanTich'
CREATE TABLE [dbo].[KQThuNghiemMau_ChiTieuPhanTich] (
    [KQThuNghiemMaus_Id] bigint  NOT NULL,
    [ChiTieuPhanTiches_Id] bigint  NOT NULL
);
GO

-- Creating table 'KQPhanTichFormKQ_ChiTieuPhanTich'
CREATE TABLE [dbo].[KQPhanTichFormKQ_ChiTieuPhanTich] (
    [KQPhanTichFormKQs_Id] bigint  NOT NULL,
    [ChiTieuPhanTiches_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PhieuYeuCaus'
ALTER TABLE [dbo].[PhieuYeuCaus]
ADD CONSTRAINT [PK_PhieuYeuCaus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MauLayHienTruongs'
ALTER TABLE [dbo].[MauLayHienTruongs]
ADD CONSTRAINT [PK_MauLayHienTruongs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChiTieuPhanTiches'
ALTER TABLE [dbo].[ChiTieuPhanTiches]
ADD CONSTRAINT [PK_ChiTieuPhanTiches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SoNhanMaus'
ALTER TABLE [dbo].[SoNhanMaus]
ADD CONSTRAINT [PK_SoNhanMaus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CacSoNhanMaus'
ALTER TABLE [dbo].[CacSoNhanMaus]
ADD CONSTRAINT [PK_CacSoNhanMaus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SoChuyenMaus'
ALTER TABLE [dbo].[SoChuyenMaus]
ADD CONSTRAINT [PK_SoChuyenMaus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CacSoChuyenMaus'
ALTER TABLE [dbo].[CacSoChuyenMaus]
ADD CONSTRAINT [PK_CacSoChuyenMaus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KQThuNghiemMaus'
ALTER TABLE [dbo].[KQThuNghiemMaus]
ADD CONSTRAINT [PK_KQThuNghiemMaus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SoKQThuNghiems'
ALTER TABLE [dbo].[SoKQThuNghiems]
ADD CONSTRAINT [PK_SoKQThuNghiems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormKQs'
ALTER TABLE [dbo].[FormKQs]
ADD CONSTRAINT [PK_FormKQs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KQPhanTichFormKQs'
ALTER TABLE [dbo].[KQPhanTichFormKQs]
ADD CONSTRAINT [PK_KQPhanTichFormKQs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NhomChiTieux'
ALTER TABLE [dbo].[NhomChiTieux]
ADD CONSTRAINT [PK_NhomChiTieux]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MauLayHienTruongs_Id], [ChiTieuPhanTiches_Id] in table 'MauLayHienTruong_ChiTieuPhanTich'
ALTER TABLE [dbo].[MauLayHienTruong_ChiTieuPhanTich]
ADD CONSTRAINT [PK_MauLayHienTruong_ChiTieuPhanTich]
    PRIMARY KEY CLUSTERED ([MauLayHienTruongs_Id], [ChiTieuPhanTiches_Id] ASC);
GO

-- Creating primary key on [SoChuyenMaus_Id], [ChiTieuPhanTiches_Id] in table 'SoChuyenMau_ChiTieuPhanTich'
ALTER TABLE [dbo].[SoChuyenMau_ChiTieuPhanTich]
ADD CONSTRAINT [PK_SoChuyenMau_ChiTieuPhanTich]
    PRIMARY KEY CLUSTERED ([SoChuyenMaus_Id], [ChiTieuPhanTiches_Id] ASC);
GO

-- Creating primary key on [KQThuNghiemMaus_Id], [ChiTieuPhanTiches_Id] in table 'KQThuNghiemMau_ChiTieuPhanTich'
ALTER TABLE [dbo].[KQThuNghiemMau_ChiTieuPhanTich]
ADD CONSTRAINT [PK_KQThuNghiemMau_ChiTieuPhanTich]
    PRIMARY KEY CLUSTERED ([KQThuNghiemMaus_Id], [ChiTieuPhanTiches_Id] ASC);
GO

-- Creating primary key on [KQPhanTichFormKQs_Id], [ChiTieuPhanTiches_Id] in table 'KQPhanTichFormKQ_ChiTieuPhanTich'
ALTER TABLE [dbo].[KQPhanTichFormKQ_ChiTieuPhanTich]
ADD CONSTRAINT [PK_KQPhanTichFormKQ_ChiTieuPhanTich]
    PRIMARY KEY CLUSTERED ([KQPhanTichFormKQs_Id], [ChiTieuPhanTiches_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PhieuYeuCauId] in table 'MauLayHienTruongs'
ALTER TABLE [dbo].[MauLayHienTruongs]
ADD CONSTRAINT [FK_PhieuYeuCau_MauLayHienTruong]
    FOREIGN KEY ([PhieuYeuCauId])
    REFERENCES [dbo].[PhieuYeuCaus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhieuYeuCau_MauLayHienTruong'
CREATE INDEX [IX_FK_PhieuYeuCau_MauLayHienTruong]
ON [dbo].[MauLayHienTruongs]
    ([PhieuYeuCauId]);
GO

-- Creating foreign key on [MauLayHienTruongs_Id] in table 'MauLayHienTruong_ChiTieuPhanTich'
ALTER TABLE [dbo].[MauLayHienTruong_ChiTieuPhanTich]
ADD CONSTRAINT [FK_MauLayHienTruong_ChiTieuPhanTich_MauLayHienTruong]
    FOREIGN KEY ([MauLayHienTruongs_Id])
    REFERENCES [dbo].[MauLayHienTruongs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ChiTieuPhanTiches_Id] in table 'MauLayHienTruong_ChiTieuPhanTich'
ALTER TABLE [dbo].[MauLayHienTruong_ChiTieuPhanTich]
ADD CONSTRAINT [FK_MauLayHienTruong_ChiTieuPhanTich_ChiTieuPhanTich]
    FOREIGN KEY ([ChiTieuPhanTiches_Id])
    REFERENCES [dbo].[ChiTieuPhanTiches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MauLayHienTruong_ChiTieuPhanTich_ChiTieuPhanTich'
CREATE INDEX [IX_FK_MauLayHienTruong_ChiTieuPhanTich_ChiTieuPhanTich]
ON [dbo].[MauLayHienTruong_ChiTieuPhanTich]
    ([ChiTieuPhanTiches_Id]);
GO

-- Creating foreign key on [CacSoNhanMauId] in table 'SoNhanMaus'
ALTER TABLE [dbo].[SoNhanMaus]
ADD CONSTRAINT [FK_CacSoNhanMau_SoNhanMau]
    FOREIGN KEY ([CacSoNhanMauId])
    REFERENCES [dbo].[CacSoNhanMaus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CacSoNhanMau_SoNhanMau'
CREATE INDEX [IX_FK_CacSoNhanMau_SoNhanMau]
ON [dbo].[SoNhanMaus]
    ([CacSoNhanMauId]);
GO

-- Creating foreign key on [MauLayHienTruong_Id] in table 'SoNhanMaus'
ALTER TABLE [dbo].[SoNhanMaus]
ADD CONSTRAINT [FK_MauLayHienTruong_SoNhanMau]
    FOREIGN KEY ([MauLayHienTruong_Id])
    REFERENCES [dbo].[MauLayHienTruongs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MauLayHienTruong_SoNhanMau'
CREATE INDEX [IX_FK_MauLayHienTruong_SoNhanMau]
ON [dbo].[SoNhanMaus]
    ([MauLayHienTruong_Id]);
GO

-- Creating foreign key on [CacSoChuyenMauId] in table 'SoChuyenMaus'
ALTER TABLE [dbo].[SoChuyenMaus]
ADD CONSTRAINT [FK_CacSoChuyenMauSoChuyenMau]
    FOREIGN KEY ([CacSoChuyenMauId])
    REFERENCES [dbo].[CacSoChuyenMaus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CacSoChuyenMauSoChuyenMau'
CREATE INDEX [IX_FK_CacSoChuyenMauSoChuyenMau]
ON [dbo].[SoChuyenMaus]
    ([CacSoChuyenMauId]);
GO

-- Creating foreign key on [SoKQThuNghiemId] in table 'KQThuNghiemMaus'
ALTER TABLE [dbo].[KQThuNghiemMaus]
ADD CONSTRAINT [FK_SoKQThuNghiemKQThuNghiemMau]
    FOREIGN KEY ([SoKQThuNghiemId])
    REFERENCES [dbo].[SoKQThuNghiems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SoKQThuNghiemKQThuNghiemMau'
CREATE INDEX [IX_FK_SoKQThuNghiemKQThuNghiemMau]
ON [dbo].[KQThuNghiemMaus]
    ([SoKQThuNghiemId]);
GO

-- Creating foreign key on [MauLayHienTruong_Id] in table 'SoChuyenMaus'
ALTER TABLE [dbo].[SoChuyenMaus]
ADD CONSTRAINT [FK_MauLayHienTruong_SoChuyenMau]
    FOREIGN KEY ([MauLayHienTruong_Id])
    REFERENCES [dbo].[MauLayHienTruongs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MauLayHienTruong_SoChuyenMau'
CREATE INDEX [IX_FK_MauLayHienTruong_SoChuyenMau]
ON [dbo].[SoChuyenMaus]
    ([MauLayHienTruong_Id]);
GO

-- Creating foreign key on [FormKQId] in table 'KQPhanTichFormKQs'
ALTER TABLE [dbo].[KQPhanTichFormKQs]
ADD CONSTRAINT [FK_FormKQ_KQPhanTichFormKQ]
    FOREIGN KEY ([FormKQId])
    REFERENCES [dbo].[FormKQs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FormKQ_KQPhanTichFormKQ'
CREATE INDEX [IX_FK_FormKQ_KQPhanTichFormKQ]
ON [dbo].[KQPhanTichFormKQs]
    ([FormKQId]);
GO

-- Creating foreign key on [SoChuyenMaus_Id] in table 'SoChuyenMau_ChiTieuPhanTich'
ALTER TABLE [dbo].[SoChuyenMau_ChiTieuPhanTich]
ADD CONSTRAINT [FK_SoChuyenMau_ChiTieuPhanTich_SoChuyenMau]
    FOREIGN KEY ([SoChuyenMaus_Id])
    REFERENCES [dbo].[SoChuyenMaus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ChiTieuPhanTiches_Id] in table 'SoChuyenMau_ChiTieuPhanTich'
ALTER TABLE [dbo].[SoChuyenMau_ChiTieuPhanTich]
ADD CONSTRAINT [FK_SoChuyenMau_ChiTieuPhanTich_ChiTieuPhanTich]
    FOREIGN KEY ([ChiTieuPhanTiches_Id])
    REFERENCES [dbo].[ChiTieuPhanTiches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SoChuyenMau_ChiTieuPhanTich_ChiTieuPhanTich'
CREATE INDEX [IX_FK_SoChuyenMau_ChiTieuPhanTich_ChiTieuPhanTich]
ON [dbo].[SoChuyenMau_ChiTieuPhanTich]
    ([ChiTieuPhanTiches_Id]);
GO

-- Creating foreign key on [KQThuNghiemMaus_Id] in table 'KQThuNghiemMau_ChiTieuPhanTich'
ALTER TABLE [dbo].[KQThuNghiemMau_ChiTieuPhanTich]
ADD CONSTRAINT [FK_KQThuNghiemMau_ChiTieuPhanTich_KQThuNghiemMau]
    FOREIGN KEY ([KQThuNghiemMaus_Id])
    REFERENCES [dbo].[KQThuNghiemMaus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ChiTieuPhanTiches_Id] in table 'KQThuNghiemMau_ChiTieuPhanTich'
ALTER TABLE [dbo].[KQThuNghiemMau_ChiTieuPhanTich]
ADD CONSTRAINT [FK_KQThuNghiemMau_ChiTieuPhanTich_ChiTieuPhanTich]
    FOREIGN KEY ([ChiTieuPhanTiches_Id])
    REFERENCES [dbo].[ChiTieuPhanTiches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KQThuNghiemMau_ChiTieuPhanTich_ChiTieuPhanTich'
CREATE INDEX [IX_FK_KQThuNghiemMau_ChiTieuPhanTich_ChiTieuPhanTich]
ON [dbo].[KQThuNghiemMau_ChiTieuPhanTich]
    ([ChiTieuPhanTiches_Id]);
GO

-- Creating foreign key on [MauLayHienTruong_Id] in table 'SoKQThuNghiems'
ALTER TABLE [dbo].[SoKQThuNghiems]
ADD CONSTRAINT [FK_SoKQThuNghiem_MauLayHienTruong]
    FOREIGN KEY ([MauLayHienTruong_Id])
    REFERENCES [dbo].[MauLayHienTruongs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SoKQThuNghiem_MauLayHienTruong'
CREATE INDEX [IX_FK_SoKQThuNghiem_MauLayHienTruong]
ON [dbo].[SoKQThuNghiems]
    ([MauLayHienTruong_Id]);
GO

-- Creating foreign key on [KQPhanTichFormKQs_Id] in table 'KQPhanTichFormKQ_ChiTieuPhanTich'
ALTER TABLE [dbo].[KQPhanTichFormKQ_ChiTieuPhanTich]
ADD CONSTRAINT [FK_KQPhanTichFormKQ_ChiTieuPhanTich_KQPhanTichFormKQ]
    FOREIGN KEY ([KQPhanTichFormKQs_Id])
    REFERENCES [dbo].[KQPhanTichFormKQs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ChiTieuPhanTiches_Id] in table 'KQPhanTichFormKQ_ChiTieuPhanTich'
ALTER TABLE [dbo].[KQPhanTichFormKQ_ChiTieuPhanTich]
ADD CONSTRAINT [FK_KQPhanTichFormKQ_ChiTieuPhanTich_ChiTieuPhanTich]
    FOREIGN KEY ([ChiTieuPhanTiches_Id])
    REFERENCES [dbo].[ChiTieuPhanTiches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KQPhanTichFormKQ_ChiTieuPhanTich_ChiTieuPhanTich'
CREATE INDEX [IX_FK_KQPhanTichFormKQ_ChiTieuPhanTich_ChiTieuPhanTich]
ON [dbo].[KQPhanTichFormKQ_ChiTieuPhanTich]
    ([ChiTieuPhanTiches_Id]);
GO

-- Creating foreign key on [NhomChiTieuId] in table 'ChiTieuPhanTiches'
ALTER TABLE [dbo].[ChiTieuPhanTiches]
ADD CONSTRAINT [FK_NhomChiTieu_ChiTieuPhanTich]
    FOREIGN KEY ([NhomChiTieuId])
    REFERENCES [dbo].[NhomChiTieux]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NhomChiTieu_ChiTieuPhanTich'
CREATE INDEX [IX_FK_NhomChiTieu_ChiTieuPhanTich]
ON [dbo].[ChiTieuPhanTiches]
    ([NhomChiTieuId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------