--Category
SET IDENTITY_INSERT [dbo].[Category] ON 
INSERT [dbo].[Category] ([Id], [ImageId], [Name], [Description]) VALUES (1, NULL, N'Business', NULL)
INSERT [dbo].[Category] ([Id], [ImageId], [Name], [Description]) VALUES (2, NULL, N'IT', NULL)
INSERT [dbo].[Category] ([Id], [ImageId], [Name], [Description]) VALUES (3, NULL, N'Language', NULL)
INSERT [dbo].[Category] ([Id], [ImageId], [Name], [Description]) VALUES (4, NULL, N'Personal Development', NULL)
INSERT [dbo].[Category] ([Id], [ImageId], [Name], [Description]) VALUES (5, NULL, N'Marketing', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF

--Subcategory
SET IDENTITY_INSERT [dbo].[Subcategory] ON 
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (1, NULL, 1, N'Accounting', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (2, NULL, 1, N'Auditing', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (3, NULL, 1, N'Costumer Service', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (4, NULL, 1, N'Human Resources', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (5, NULL, 2, N'Programming', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (6, NULL, 2, N'AWS', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (7, NULL, 2, N'Computer Network', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (8, NULL, 2, N'Data Science', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (9, NULL, 2, N'Cyber Security', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (10, NULL, 2, N'Server', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (11, NULL, 2, N'Databases', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (12, NULL, 3, N'English', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (13, NULL, 3, N'Spanish', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (14, NULL, 3, N'Portuguese', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (17, NULL, 3, N'Brazilian Portuguese', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (18, NULL, 4, N'Communication Skill', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (19, NULL, 4, N'Mental Health', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (20, NULL, 4, N'Personal Finance', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (25, NULL, 4, N'Psycohology', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (26, NULL, 5, N'Advertising', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (27, NULL, 5, N'Amazon', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (28, NULL, 5, N'Digital Marketing', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (29, NULL, 5, N'Social Media', NULL)
INSERT [dbo].[Subcategory] ([Id], [ImageId], [CategoryId], [Name], [Description]) VALUES (30, NULL, 5, N'Marketing Strategy', NULL)
SET IDENTITY_INSERT [dbo].[Subcategory] OFF