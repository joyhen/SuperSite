USE [SuperSite]
GO
/****** Object:  Table [dbo].[SysUser]    Script Date: 12/04/2015 16:58:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[RealName] [nvarchar](20) NOT NULL,
	[Gender] [tinyint] NULL,
	[Photo] [nvarchar](50) NULL,
	[RoleTag] [bigint] NOT NULL,
	[State] [tinyint] NOT NULL,
	[Question] [xml] NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_sysuser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户性别,0女性，1男性，>=2中性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户图像地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户分配的角色Id（与 算法）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'RoleTag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态：0禁用，1正常，2删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录口令' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Question'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
SET IDENTITY_INSERT [dbo].[SysUser] ON
INSERT [dbo].[SysUser] ([Id], [UserName], [Password], [RealName], [Gender], [Photo], [RoleTag], [State], [Question], [AddTime]) VALUES (2, N'admin', N'8c581610fac95907f78680a2422c111b', N'周志龙', NULL, NULL, 0, 1, N'', CAST(0x0000A56001259A7F AS DateTime))
SET IDENTITY_INSERT [dbo].[SysUser] OFF
/****** Object:  Table [dbo].[BizNoticeType]    Script Date: 12/04/2015 16:58:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BizNoticeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NULL,
	[Description] [nvarchar](50) NULL,
	[AdvanceDay] [int] NULL,
	[Open] [bit] NULL,
	[Reserved1] [nvarchar](10) NULL,
	[AddUser] [nvarchar](10) NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_BizNoticeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提前多少天通知' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'AdvanceDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启用状态，0未启用，1启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'Open'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预留字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'Reserved1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'AddUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知类别，对应NoticeCategory枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'Category'
GO
SET IDENTITY_INSERT [dbo].[BizNoticeType] ON
INSERT [dbo].[BizNoticeType] ([Id], [Name], [Description], [AdvanceDay], [Open], [Reserved1], [AddUser], [AddTime], [UpdateTime], [Category]) VALUES (1, N'项目兑付', N'财务在CRM上点项目兑付时，发起本通知', 0, 0, NULL, N'admin', CAST(0x0000A56400BEF2F4 AS DateTime), NULL, 0)
INSERT [dbo].[BizNoticeType] ([Id], [Name], [Description], [AdvanceDay], [Open], [Reserved1], [AddUser], [AddTime], [UpdateTime], [Category]) VALUES (2, N'发标通知', N'发一个项目则有自动推送，xx标发标，如果是提前标还需表明开售时间', 0, 1, N'', N'admin', CAST(0x0000A56401105334 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[BizNoticeType] OFF
/****** Object:  Default [DF_BizNoticeType_AdvanceDay]    Script Date: 12/04/2015 16:58:49 ******/
ALTER TABLE [dbo].[BizNoticeType] ADD  CONSTRAINT [DF_BizNoticeType_AdvanceDay]  DEFAULT ((0)) FOR [AdvanceDay]
GO
/****** Object:  Default [DF_BizNoticeType_Open]    Script Date: 12/04/2015 16:58:49 ******/
ALTER TABLE [dbo].[BizNoticeType] ADD  CONSTRAINT [DF_BizNoticeType_Open]  DEFAULT ((0)) FOR [Open]
GO
/****** Object:  Default [DF_SysUser_RoleTag]    Script Date: 12/04/2015 16:58:49 ******/
ALTER TABLE [dbo].[SysUser] ADD  CONSTRAINT [DF_SysUser_RoleTag]  DEFAULT ((0)) FOR [RoleTag]
GO
/****** Object:  Default [DF_sysuser_State]    Script Date: 12/04/2015 16:58:49 ******/
ALTER TABLE [dbo].[SysUser] ADD  CONSTRAINT [DF_sysuser_State]  DEFAULT ((1)) FOR [State]
GO
/****** Object:  Default [DF_sysuser_AddTime]    Script Date: 12/04/2015 16:58:49 ******/
ALTER TABLE [dbo].[SysUser] ADD  CONSTRAINT [DF_sysuser_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
