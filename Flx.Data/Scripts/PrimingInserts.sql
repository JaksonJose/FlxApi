--Category
SET IDENTITY_INSERT [dbo].[Category] ON 
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration]) VALUES (1, N'Business', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration]) VALUES (2, N'IT', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration]) VALUES (3, N'Language', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration]) VALUES (4, N'Personal Development', NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration]) VALUES (5, N'Marketing', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF

--Subcategory
SET IDENTITY_INSERT [dbo].[Subcategory] ON 
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (1, 1, N'Accounting', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (2, 1, N'Auditing', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (3, 1, N'Costumer Service', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (4, 1, N'Human Resources', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (5, 2, N'Programming', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (6, 2, N'AWS', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (7, 2, N'Computer Network', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (8, 2, N'Data Science', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (9, 2, N'Cyber Security', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (10, 2, N'Server', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (11, 2, N'Databases', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (12, 3, N'English', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (13, 3, N'Spanish', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (14, 3, N'Portuguese', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (17, 3, N'Brazilian Portuguese', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (18, 4, N'Communication Skill', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (19, 4, N'Mental Health', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (20, 4, N'Personal Finance', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (25, 4, N'Psycohology', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (26, 5, N'Advertising', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (27, 5, N'Amazon', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (28, 5, N'Digital Marketing', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (29, 5, N'Social Media', NULL)
INSERT [dbo].[Subcategory] ([Id], [CategoryId], [Name], [Description]) VALUES (30, 5, N'Marketing Strategy', NULL)
SET IDENTITY_INSERT [dbo].[Subcategory] OFF