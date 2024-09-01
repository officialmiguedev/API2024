USE [AcademyOnline]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Categorias] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursoes](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[InstructorId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Cursoes] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCursoes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](1000) NOT NULL,
	[CursoId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DetalleCursoes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiantes](
	[EstudianteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Clave] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_dbo.Estudiantes] PRIMARY KEY CLUSTERED 
(
	[EstudianteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructors](
	[InstructorId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[SobreMi] [nvarchar](50) NOT NULL,
	[Youtube] [nvarchar](50) NOT NULL,
	[Linkedln] [nvarchar](50) NOT NULL,
	[Twitter] [nvarchar](50) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Instructors] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leccions](
	[LeccionId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[TemaId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Leccions] PRIMARY KEY CLUSTERED 
(
	[LeccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temas](
	[TemaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[CursoId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Temas] PRIMARY KEY CLUSTERED 
(
	[TemaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202212011948260_Migration', N'AcademyOnline.DataAccess.Migrations.Configuration', 0x1F8B0800000000000400DD5BDB6EE336107D2FD07F10F4D402D928C9A2401BD8BBC8DA49613497C53A59A08FB4347688A52855A452FBDBFAD04FEA2F94D49594758FECD88B7D8929CE99E1F00C2FC3D9FFFEF977F471ED12E30502863D3A36CF4FCF4C03A8ED3998AEC666C897EF7E353F7EF8F187D1B5E3AE8DAF69BFF7B29F90A46C6C3E73EE5F5A16B39FC145ECD4C576E0316FC94F6DCFB590E359176767BF59E7E7160808536019C6E84B48397621FA217E4E3C6A83CF4344EE3C07084BDAC59779846ADC2317988F6C189B573672C0DD3C5082299C4E114757B60D8C457F9AC615C148183507B2340D44A9C71117265F3E3198F3C0A3ABB92F1A1079DCF820FA2D1161900CE532EFDE765467177254562E9842D921E39EDB11F0FC7DE226AB28DECBD966E646E1C86BE170BE91A38E9C39362788C3CA0BB0F05951DBE58404B267D1D9110606769AC99E18E53D4E32AA0846C97F27C624243C0C604C21E4012227C6E77041B0FD076C1EBD6F40C7342444B558D82CBE690DA2E973E0F910F0CD175816C731734CC3D201AC2242265F261C0F7946F9FB0BD3B817E6A005818C228A7BE6DC0BE077A0100871E733E21C0231C3330722276F9951507AEFB98B00527D829522D64CE30EAD6F81AEF8B388C233115D37780D4EDA92D8F044B1084D21C483104A6CACD73B73D10A84B5CF35AAC59FAD54AB9A46564EAE7ACA8501F3FAD04DCA1D02D5A41DBD68960A7EEF14BB01FB19A56AC5820C8F6295EF4E54CA84765BB8A0D967F5481DE2FBC063670A1C11027D4348153F80489A4DBB079194D957FC4C81D901F6ED68EBAD0BA29D4451CBE5A2178FAE190F1D8C28871E2CCA850F8043B9317D96645DFA60D6E55F7642A82B1F08C18EB777C5D72EC264EF5A2704BDD46F7EAFD7DA3AE0F2CDAC47C0E5C2071070FAB6DC79F9EEB0A91F7DC03D621E92FD87DBDC1383BDC37BD7FBA717F270B17F37DF62FA0D1C52B747EF687EFFC692887BD7FBE6C7D05BB0E34351E7A52C913C80752CB1A4CF22A6887EEF2B18B81D2F4DAD3924A17B10488A1D007B52C774A54E3B871E7F0A60F0CBCBC4A31C89C90EB2C3AC3FFD241B61CD4B68F4C42061124B46A09B1B83CE812770769A2260A6919B1167904F9524A9D50023875D0A11DFD81BC49DF87ECE265530FAFDBF010D1847C9EDA60C4BBD033620E1ECD4568AA41E6E1B9048BC7496C264BB4A03069749EF12F9784529A354469EFC49C18ADF14D2B707ABE2F16174877C5FC48CF21891B418F3F82562F26EDE3D2FEFC61896CD4AD2F399B59926E159B1E317BE0AD5C2D21B1C302E1F3D164806D4C471B7BA69A152E1DA54D556341497C2DCEBA988FC3B89C9BA4719258A0A98B94F6FC4305DB1B0452386CC38F599624B367A1E4204057549BF89474297363E15D4E1A52BA90A95B6B547518E6E2A90D2BC8D35B20AEE29CE89B53529855DA938CDED48102F420312205AB57A4C7EB95CE5C4A75B8F36E9E549FBDD4F78920B574192A60EA4D12ECD1A6F6A2EE3B53E1A38388E88D6853D76387A6B7B737796D78B573A7E5AF0F8564ABD4E5A4B70AB30DA870EB4EA187A6F4401ED60341C01940355F7E9AF13AE72B79EBD567D5E9715AF431C66CDCB13CD2A4EDEDA1E29C91C6B438B9B3A9032CE036B948C9B0E8690DAF97A38422AE7F2EE84AC13DEDF46350C21D344AC8A92B6B547C9F2AA2A4CD6D81E27CB93AA3859637B9C3CEFA902E5AD1DFC9326323507A58DDFE53120BF880E176FE905B67BB0554A56CE7D9E82D426BF2AA9598735508C25992D8D42A559B2379CF5387530DC8C472987EED35D2E368C67773BCB0775C2DB4AEF14BB64DAB3344F219D334A522BCD05A75BB996B88B690807BD6047E659E61B26F8151363FE1799102CC69B77B843142FC5D1334E3C9B1767E7178542D5C3291AB5187348DBCAD11EE9F3A1CB35B1747463AABC630E5BCF9DD31714887B7BB09D3D7FEDEB5D8AFC938BD63FAB70AF2EB2EC33330355371ED38C68F58A8E30950F55AF1879E1F5D58A7D60F642B3EAA4C53E2A0077C2B192A2BF2AA275675A59900C5ED1D7631E86AFA27BABF8FFA5FBA414EBE286C2D5CADE8602D5AADA2A88B983A2B53EB13D78A1D811714A2FFD1A0AB550D935146CA1706B28D8625DD660BED5CBAE8682DDCB86597AD1DF7FC1D2314592563133E08EB97D09DF67E9CF319D8F073EB5144B79B6CB182A72395B37CFDA529DF8822E0EF40BB90EC7B64E94329F862A93A4C6A6AA92A7145D7E826668BD8AA7A1C8A74C91DAA3853EB5D2A7B60CA84C57FEBD59915A08545B2554A628FFDEAC282B15AA2E222A53917C6CC68F4B892A2A8CCA901FE39AA49EC547DB59A891A5FEE7E891B894E0550E21FFAB34055BA67772D0B4CF8C2EBD3480C588548BD22E85F8BE137472646633E078896C2E3ECB1467542AF81591303ACB2EC099D18790FB21BF620CDC05D18A0F4756BDFEA8C24AB779F4E0CB5F6C88210833B1BCB93FD04F21264E66F74DC9E254012197A1642D1656CDB95C93579B0CE9DEA32D8112F74DC1072A5772C10D9F0830F640E7D1E1BDBB6D4F0C6E6185EC4D9A4CAC06699E08DDEDA32946AB00B92CC1C8E5C54FC161C75D7FF81F08A56A1D23400000, N'6.4.4')
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([CategoriaId], [Nombre], [ImagePath]) VALUES (1, N'Programación', N'1500x844_TICS.jpg')
INSERT [dbo].[Categorias] ([CategoriaId], [Nombre], [ImagePath]) VALUES (2, N'Diseño WEB', N'disenho-web.png')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Cursoes] ON 

INSERT [dbo].[Cursoes] ([CursoId], [Nombre], [Fecha], [InstructorId], [CategoriaId], [ImagePath]) VALUES (1, N'Python', CAST(N'2022-12-01T00:00:00.000' AS DateTime), 1, 1, N'python.png')
INSERT [dbo].[Cursoes] ([CursoId], [Nombre], [Fecha], [InstructorId], [CategoriaId], [ImagePath]) VALUES (2, N'HTML 5', CAST(N'2022-12-01T00:00:00.000' AS DateTime), 1, 2, N'html.png')
SET IDENTITY_INSERT [dbo].[Cursoes] OFF
GO
SET IDENTITY_INSERT [dbo].[Instructors] ON 

INSERT [dbo].[Instructors] ([InstructorId], [Nombre], [Titulo], [SobreMi], [Youtube], [Linkedln], [Twitter], [ImagePath]) VALUES (1, N'Linux', N'Computación', N'Dev', N'yt', N'lk', N'tw', N'linus.jpg')
SET IDENTITY_INSERT [dbo].[Instructors] OFF
GO
SET IDENTITY_INSERT [dbo].[Leccions] ON 

INSERT [dbo].[Leccions] ([LeccionId], [Nombre], [TemaId]) VALUES (1, N'Conociendo python', 1)
INSERT [dbo].[Leccions] ([LeccionId], [Nombre], [TemaId]) VALUES (2, N'Enteros', 2)
INSERT [dbo].[Leccions] ([LeccionId], [Nombre], [TemaId]) VALUES (3, N'coma flotante', 2)
INSERT [dbo].[Leccions] ([LeccionId], [Nombre], [TemaId]) VALUES (4, N'boolean', 2)
INSERT [dbo].[Leccions] ([LeccionId], [Nombre], [TemaId]) VALUES (5, N'Introducción a POO', 3)
SET IDENTITY_INSERT [dbo].[Leccions] OFF
GO
SET IDENTITY_INSERT [dbo].[Temas] ON 

INSERT [dbo].[Temas] ([TemaId], [Nombre], [CursoId]) VALUES (1, N'Introducción', 1)
INSERT [dbo].[Temas] ([TemaId], [Nombre], [CursoId]) VALUES (2, N'Tipos de datos', 1)
INSERT [dbo].[Temas] ([TemaId], [Nombre], [CursoId]) VALUES (3, N'Objetos', 1)
SET IDENTITY_INSERT [dbo].[Temas] OFF
GO
