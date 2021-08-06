--------------------------------Usser Roles --------------------------
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
INSERT [dbo].[UserRoles] ([id],[Name]) VALUES (1 , N'MxAdmin')
INSERT [dbo].[UserRoles] ([id],[Name]) VALUES (2 , N'Admin')
INSERT [dbo].[UserRoles] ([id],[Name]) VALUES (3 , N'Employee')
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
------------------------------- MxAdmin -------------------------------
SET IDENTITY_INSERT [dbo].[Users] ON 
INSERT [dbo].[Users] ([id],[UserName],[Email],[UserRoleID],[Number],[Password])
VALUES (1 , N'MxAdmin' , N'rolarolamuhareb@hotmail.com',1,N'0790626391',N'P@ssw0rd')
SET IDENTITY_INSERT [dbo].[Users] OFF
--------------------------------Department --------------------------
SET IDENTITY_INSERT [dbo].[Department] ON 
INSERT [dbo].[UserRoles] ([id],[Name]) VALUES (1 , N'Backend')
INSERT [dbo].[UserRoles] ([id],[Name]) VALUES (2 , N'Frontend')
INSERT [dbo].[UserRoles] ([id],[Name]) VALUES (3 , N'Database')
INSERT [dbo].[UserRoles] ([id],[Name]) VALUES (4 , N'Android')
INSERT [dbo].[UserRoles] ([id],[Name]) VALUES (5 , N'IOS')
SET IDENTITY_INSERT [dbo].[Department] OFF