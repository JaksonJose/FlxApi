
--Category
DELETE FROM [dbo].[Category];
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (1, 'Advanced English', 'Description Default', 120, 'https://img2.gratispng.com/20180316/puq/kisspng-flag-of-england-flag-of-the-united-states-flag-of-vector-american-flag-5aab73f8bab397.8804847715211857847647.jpg')
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (2, 'Basic English', 'Description Default', 180, 'https://img2.gratispng.com/20180316/puq/kisspng-flag-of-england-flag-of-the-united-states-flag-of-vector-american-flag-5aab73f8bab397.8804847715211857847647.jpg')
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (3, 'Intermadiate English', 'Description Default', 140, 'https://img2.gratispng.com/20180316/puq/kisspng-flag-of-england-flag-of-the-united-states-flag-of-vector-american-flag-5aab73f8bab397.8804847715211857847647.jpg')
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (4, 'DotNet Core', 'Description Default', 140, 'https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/1200px-.NET_Core_Logo.svg.png')
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (5, 'Master ECMAScript', 'Description Default', 140, 'https://blog.betrybe.com/wp-content/uploads/2021/08/1_SL4sWHdjGR3vo0x5ta3xfw.jpeg')
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (6, 'Master Angular', 'Description Default', 140, 'https://devkico.itexto.com.br/wp-content/uploads/2016/04/angular-js_600x400.png')
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (7, 'Master React', 'Description Default', 140, 'https://miro.medium.com/max/1400/0*1V_xALlt1BCKvFBW.jpeg')
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (8, 'Master React Native', 'Description Default', 140, 'https://originapps.io/wp-content/uploads/2019/03/React-Native.png')
INSERT [dbo].[Category] ([Id], [Name], [Description], [Duration], [ImgUrl]) VALUES (9, 'Master Ionic', 'Description Default', 140, 'https://ionicframework.com/img/meta/ionic-framework-og.png')
SET IDENTITY_INSERT [dbo].[Category] OFF

--Subcategory
DELETE FROM [dbo].Subcategory;
SET IDENTITY_INSERT [dbo].Subcategory ON
INSERT [dbo].[Subcategory] ([Id], [SubcategoryId], [Name], [Description]) VALUES (1, 1, N'Use of Wish', N'Here you see a lesson about how to use ''wish'' word,')
INSERT [dbo].[Subcategory] ([Id], [SubcategoryId], [Name], [Description]) VALUES (2, 1, N'Future tense', N'Here you see how to use future tense')
INSERT [dbo].[Subcategory] ([Id], [SubcategoryId], [Name], [Description]) VALUES (3, 1, N'There is, Ther are', N'Here you learn how to use ''there is'' and ''ther are'' in the correct context.')
INSERT [dbo].[Subcategory] ([Id], [SubcategoryId], [Name], [Description]) VALUES (4, 2, N'Present tense', N'Here you will learn everything about the present tense.')
INSERT [dbo].[Subcategory] ([Id], [SubcategoryId], [Name], [Description]) VALUES (5, 2, N'Present continuos tense', N'Here you will learn everything about present continuous tense.')
INSERT [dbo].[Subcategory] ([Id], [SubcategoryId], [Name], [Description]) VALUES (6, 2, N'Past tense - regular verbs', N'Here you will learn everything about past tense regular verbs')
INSERT [dbo].[Subcategory] ([Id], [SubcategoryId], [Name], [Description]) VALUES (7, 2, N'Past tense - irregular verbs', N'Here you will learn everything about irregular verbs.')
INSERT [dbo].[Subcategory] ([Id], [SubcategoryId], [Name], [Description]) VALUES (8, 3, N'How to pronounce ''Th'' sound', N'Here you learn the pronouciation of ''th'' sound.')
SET IDENTITY_INSERT [dbo].[Lessons] OFF