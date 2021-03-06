USE [SuperSite]
GO
/****** Object:  Table [dbo].[SysUser]    Script Date: 01/27/2016 17:08:00 ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 01/27/2016 17:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](10) NOT NULL,
	[Url] [nvarchar](50) NOT NULL,
	[SiteModel] [int] NULL,
	[ListTemplate] [nvarchar](50) NULL,
	[ContentTemplate] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[TargetBlank] [bit] NULL,
	[ShowFoot] [bit] NULL,
	[SortNumber] [tinyint] NULL,
	[Img] [nvarchar](10) NULL,
	[Content] [nvarchar](max) NULL,
	[AddTime] [datetime] NOT NULL,
	[AddUser] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Url地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目模型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'SiteModel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列表模板地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ListTemplate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容模板地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ContentTemplate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用，1是，0否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新窗口打开，1是，0否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'TargetBlank'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'底部显示，1是，0否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ShowFoot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'SortNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Img'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'详细内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'AddUser'
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (2, 0, N'关于我们', N'about.aspx', 1, N'', N'', 1, 1, 1, 1, NULL, N'', CAST(0x0000A599012547E9 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (3, 2, N'公司简介', N'brief.aspx', 2, N'', N'', 1, 1, 1, 2, NULL, N'', CAST(0x0000A59901263BCF AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (4, 2, N'企业文化', N'culture.aspx', 1, N'', N'', 1, 1, 1, 2, NULL, N'', CAST(0x0000A59A00A8744F AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (5, 2, N'公司架构', N'structure.aspx', 1, N'', N'', 1, 1, 1, 0, NULL, N'', CAST(0x0000A59A00A8A92E AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (6, 2, N'联系我们', N'contact.aspx', 1, N'', N'', 1, 1, 1, 4, NULL, N'', CAST(0x0000A59A00A8E6DC AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (7, 0, N'新闻资讯', N'news.aspx', 2, N'', N'', 1, 1, 1, 1, NULL, N'', CAST(0x0000A59A00A9B527 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (8, 7, N'公司新闻', N'companynews.aspx', 2, N'', N'', 1, 1, 1, 1, NULL, N'', CAST(0x0000A59A00A9D648 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (9, 7, N'动态新闻', N'dynamic', 2, N'', N'', 1, 1, 1, 2, NULL, N'', CAST(0x0000A59A00A9F78F AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (10, 0, N'案例展示', N'product.aspx', 3, N'', N'', 1, 1, 1, 0, NULL, N'', CAST(0x0000A59A00AA919A AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (11, 10, N'办公医疗', N'work.aspx', 4, N'', N'', 1, 1, 1, 1, NULL, N'', CAST(0x0000A59A00ABB6B8 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (12, 10, N'公共设施', N'public.aspx', 4, N'', N'', 1, 1, 1, 2, NULL, N'', CAST(0x0000A59A00AC30A4 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (13, 10, N'酒店会所', N'hotel.aspx', 4, N'', N'', 1, 1, 1, 3, NULL, N'', CAST(0x0000A59A00AC5694 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (14, 10, N'精装修房', N'house.aspx', 4, N'', N'', 1, 1, 1, 4, NULL, N'', CAST(0x0000A59A00AC7C47 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (15, 0, N'客户服务', N'service.aspx', 1, N'', N'', 1, 1, 1, 0, NULL, N'', CAST(0x0000A59A00ACBE6A AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (16, 15, N'工程保修', N'', 1, N'', N'', 1, 1, 1, 1, NULL, N'', CAST(0x0000A59A00AD6CDA AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (17, 15, N'装修流程', N'', 1, N'', N'', 1, 1, 1, 2, NULL, N'', CAST(0x0000A59A00ADA8A9 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (18, 15, N'在线反馈', N'', 1, N'', N'', 1, 1, 1, 3, NULL, N'', CAST(0x0000A59A00ADBA3B AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (19, 15, N'联系我们', N'', 1, N'', N'', 1, 1, 1, 4, NULL, N'', CAST(0x0000A59A00ADCED5 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (20, 0, N'在线招聘', N'job.aspx', 1, N'', N'', 1, 1, 1, 0, NULL, N'', CAST(0x0000A59A00AE15D1 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (21, 0, N'联系我们', N'contact.aspx', 1, N'', N'', 1, 1, 1, 5, NULL, N'', CAST(0x0000A59A00AE3DE8 AS DateTime), N'admin')
INSERT [dbo].[Category] ([Id], [ParentId], [Name], [Url], [SiteModel], [ListTemplate], [ContentTemplate], [Status], [TargetBlank], [ShowFoot], [SortNumber], [Img], [Content], [AddTime], [AddUser]) VALUES (22, 0, N'首页', N'index.aspx', 1, N'', N'', 1, 1, 1, 0, NULL, N'', CAST(0x0000A59A00FCFC8C AS DateTime), N'admin')
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[BizQuartzScheduler]    Script Date: 01/27/2016 17:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BizQuartzScheduler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [int] NULL,
	[MobileType] [tinyint] NULL,
	[MessageType] [tinyint] NULL,
	[PushTime] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_QuartzScheduler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizQuartzScheduler', @level2type=N'COLUMN',@level2name=N'MessageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户端对象,具体参考ClientType枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizQuartzScheduler', @level2type=N'COLUMN',@level2name=N'MobileType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推送消息客户端呈现方式，具体参考PushMessageType枚举' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizQuartzScheduler', @level2type=N'COLUMN',@level2name=N'MessageType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推送时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizQuartzScheduler', @level2type=N'COLUMN',@level2name=N'PushTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推送状态，0未推送，1推送成功，2提送失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizQuartzScheduler', @level2type=N'COLUMN',@level2name=N'Status'
GO
SET IDENTITY_INSERT [dbo].[BizQuartzScheduler] ON
INSERT [dbo].[BizQuartzScheduler] ([Id], [MessageId], [MobileType], [MessageType], [PushTime], [Status]) VALUES (11, 5, 0, 0, CAST(0x0000A572014EA122 AS DateTime), 1)
INSERT [dbo].[BizQuartzScheduler] ([Id], [MessageId], [MobileType], [MessageType], [PushTime], [Status]) VALUES (12, 5, 0, 0, CAST(0x0000A56F01443738 AS DateTime), 0)
INSERT [dbo].[BizQuartzScheduler] ([Id], [MessageId], [MobileType], [MessageType], [PushTime], [Status]) VALUES (13, 5, 0, 0, CAST(0x0000A57001443738 AS DateTime), 0)
INSERT [dbo].[BizQuartzScheduler] ([Id], [MessageId], [MobileType], [MessageType], [PushTime], [Status]) VALUES (14, 5, 0, 0, CAST(0x0000A57201443738 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BizQuartzScheduler] OFF
/****** Object:  Table [dbo].[BizNoticeType]    Script Date: 01/27/2016 17:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BizNoticeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NULL,
	[Description] [nvarchar](50) NULL,
	[AdvanceDay] [nvarchar](10) NULL,
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提前多少天通知,英文逗号（,）分隔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeType', @level2type=N'COLUMN',@level2name=N'AdvanceDay'
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
INSERT [dbo].[BizNoticeType] ([Id], [Name], [Description], [AdvanceDay], [Open], [Reserved1], [AddUser], [AddTime], [UpdateTime], [Category]) VALUES (1, N'项目兑付', N'财务在CRM上点项目兑付时，发起本通知', N'0', 0, NULL, N'admin', CAST(0x0000A56400BEF2F4 AS DateTime), NULL, 0)
INSERT [dbo].[BizNoticeType] ([Id], [Name], [Description], [AdvanceDay], [Open], [Reserved1], [AddUser], [AddTime], [UpdateTime], [Category]) VALUES (2, N'发标通知', N'发一个项目则有自动推送，xx标发标，如果是提前标还需表明开售时间', N'0', 1, N'', N'admin', CAST(0x0000A56401105334 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), 3)
INSERT [dbo].[BizNoticeType] ([Id], [Name], [Description], [AdvanceDay], [Open], [Reserved1], [AddUser], [AddTime], [UpdateTime], [Category]) VALUES (4, N'代金券通知', N'用户获取代金券的时候发送通知', N'0', 1, N'', N'admin', CAST(0x0000A569010DCCE9 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), 2)
INSERT [dbo].[BizNoticeType] ([Id], [Name], [Description], [AdvanceDay], [Open], [Reserved1], [AddUser], [AddTime], [UpdateTime], [Category]) VALUES (14, N'测试类型', N'范德萨', N'4,0', 1, N'fdsfds', N'admin', CAST(0x0000A57700A41667 AS DateTime), CAST(0x00008EAC00000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BizNoticeType] OFF
/****** Object:  Table [dbo].[BizNoticeRecord]    Script Date: 01/27/2016 17:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BizNoticeRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShowType] [tinyint] NULL,
	[MobileType] [tinyint] NULL,
	[Message] [nvarchar](150) NULL,
	[TypeId] [int] NULL,
	[Category] [int] NULL,
	[PushTime] [datetime] NULL,
	[Status] [tinyint] NULL,
	[UpdateTime] [datetime] NULL,
	[AddUser] [nvarchar](10) NULL,
	[AddTime] [datetime] NULL,
 CONSTRAINT [PK_BizNoticeRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推送的消息在移动端呈现的方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'ShowType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接受的终端类型，参考ClientType枚举类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'MobileType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推送内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'Message'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息类型id，对应BizNoticeType表的Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'TypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推送的时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'PushTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息发送状态，0默认，1成功，2失败，10已读取到计划任务表中' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新状态Status时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'AddUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizNoticeRecord', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
SET IDENTITY_INSERT [dbo].[BizNoticeRecord] ON
INSERT [dbo].[BizNoticeRecord] ([Id], [ShowType], [MobileType], [Message], [TypeId], [Category], [PushTime], [Status], [UpdateTime], [AddUser], [AddTime]) VALUES (5, 0, 0, N'这个消息是测试的，看看能否收到', 13, 0, CAST(0x0000A57201443738 AS DateTime), 10, CAST(0x00008EAC00000000 AS DateTime), N'admin', CAST(0x0000A57100F75730 AS DateTime))
SET IDENTITY_INSERT [dbo].[BizNoticeRecord] OFF
/****** Object:  Table [dbo].[BizMessageHistory]    Script Date: 01/27/2016 17:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BizMessageHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [int] NULL,
	[PushTime] [datetime] NULL,
	[IOS] [int] NULL,
	[Android] [int] NULL,
	[WindowsPhone] [int] NULL,
	[Web] [int] NULL,
	[Lose] [int] NULL,
 CONSTRAINT [PK_BizMessageHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizMessageHistory', @level2type=N'COLUMN',@level2name=N'MessageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推送时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BizMessageHistory', @level2type=N'COLUMN',@level2name=N'PushTime'
GO
/****** Object:  Default [DF_BizNoticeType_AdvanceDay]    Script Date: 01/27/2016 17:08:00 ******/
ALTER TABLE [dbo].[BizNoticeType] ADD  CONSTRAINT [DF_BizNoticeType_AdvanceDay]  DEFAULT ((0)) FOR [AdvanceDay]
GO
/****** Object:  Default [DF_BizNoticeType_Open]    Script Date: 01/27/2016 17:08:00 ******/
ALTER TABLE [dbo].[BizNoticeType] ADD  CONSTRAINT [DF_BizNoticeType_Open]  DEFAULT ((0)) FOR [Open]
GO
/****** Object:  Default [DF_Category_Status]    Script Date: 01/27/2016 17:08:00 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_SysUser_RoleTag]    Script Date: 01/27/2016 17:08:00 ******/
ALTER TABLE [dbo].[SysUser] ADD  CONSTRAINT [DF_SysUser_RoleTag]  DEFAULT ((0)) FOR [RoleTag]
GO
/****** Object:  Default [DF_sysuser_State]    Script Date: 01/27/2016 17:08:00 ******/
ALTER TABLE [dbo].[SysUser] ADD  CONSTRAINT [DF_sysuser_State]  DEFAULT ((1)) FOR [State]
GO
/****** Object:  Default [DF_sysuser_AddTime]    Script Date: 01/27/2016 17:08:00 ******/
ALTER TABLE [dbo].[SysUser] ADD  CONSTRAINT [DF_sysuser_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
