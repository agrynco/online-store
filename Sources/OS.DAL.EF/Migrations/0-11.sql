-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.11'

DECLARE @currentDbVersion       VARCHAR(11)
SET @currentDbVersion = dbo.GetCurrentDbVersionAsString()

DECLARE @errorMessage NVARCHAR(500);

IF dbo.CompareDbVersionWithCurrent(@newDbVersion) <> 1
BEGIN
    SET @errorMessage = 'Cannot install script ' + @newDbVersion + '. DB version ' + @currentDbVersion + ' expected.'
    RAISERROR(@errorMessage, 20, -1) WITH LOG
END
GO
-- End checking possibility of using

-- BEGIN CHANGES

SET IDENTITY_INSERT [dbo].[Countries] ON 

GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (1, N'Australia', N'036', N'+61', N'AU', N'AUS', N'Австралия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (2, N'Austria', N'040', N'+43', N'AT', N'AUT', N'Австрия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (3, N'Azerbaijan', N'031', N'+994', N'AZ', N'AZE', N'Азербайджан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (4, N'Albania', N'008', N'+355', N'AL', N'ALB', N'Албания', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (5, N'Algeria', N'012', N'+213', N'DZ', N'DZA', N'Алжир', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (6, N'American Samoa', N'016', N'+685', N'AS', N'ASM', N'Американское Самоа', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (7, N'Anguilla', N'660', N'+1264', N'AI', N'AIA', N'Ангилья', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (8, N'Angola', N'024', N'+244', N'AO', N'AGO', N'Ангола', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (9, N'Andorra', N'020', N'+376', N'AD', N'AND', N'Андорра', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (10, N'Antarctica', N'010', N'', N'AQ', N'ATA', N'Антарктида', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (11, N'Antigua and Barbuda', N'028', N'+1268', N'AG', N'ATG', N'Антигуа и Барбуда', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (12, N'Argentina', N'032', N'+54', N'AR', N'ARG', N'Аргентина', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (13, N'Armenia', N'051', N'+374', N'AM', N'ARM', N'Армения', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (14, N'Aruba', N'533', N'+297', N'AW', N'ABW', N'Аруба', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (15, N'Afghanistan', N'004', N'+93', N'AF', N'AFG', N'Афганистан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (16, N'The Bahamas', N'044', N'+1242', N'BS', N'BHS', N'Багамы', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (17, N'Bangladesh', N'050', N'+880', N'BD', N'BGD', N'Бангладеш', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (18, N'Barbados', N'052', N'+1246', N'BB', N'BRB', N'Барбадос', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (19, N'Bahrain', N'048', N'+973', N'BH', N'BHR', N'Бахрейн', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (20, N'Belarus', N'112', N'+375', N'BY', N'BLR', N'Беларусь', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (21, N'Belize', N'084', N'+501', N'BZ', N'BLZ', N'Белиз', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (22, N'Belgium', N'056', N'+32', N'BE', N'BEL', N'Бельгия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (23, N'Benin', N'204', N'+229', N'BJ', N'BEN', N'Бенин', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (24, N'Bermuda', N'060', N'+1441', N'BM', N'BMU', N'Бермудские острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (25, N'Bulgaria', N'100', N'+359', N'BG', N'BGR', N'Болгария', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (26, N'Bolivia', N'068', N'+591', N'BO', N'BOL', N'Боливия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (27, N'Bosnia and Herzegovina', N'070', N'+387', N'BA', N'BIH', N'Босния и Герцеговина', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (28, N'Botswana', N'072', N'+267', N'BW', N'BWA', N'Ботсвана', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (29, N'Brazil', N'076', N'+55', N'BR', N'BRA', N'Бразилия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (30, N'British Indian Ocean Territory', N'086', N'', N'IO', N'IOT', N'Британская территория в Индийском океане', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (31, N'Brunei', N'096', N'+673', N'BN', N'BRN', N'Бруней-Даруссалам', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (32, N'Burkina Faso', N'854', N'+226', N'BF', N'BFA', N'Буркина-Фасо', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (33, N'Burundi', N'108', N'+257', N'BI', N'BDI', N'Бурунди', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (34, N'Bhutan', N'064', N'+975', N'BT', N'BTN', N'Бутан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (35, N'Vanuatu', N'548', N'+678', N'VU', N'VUT', N'Вануату', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (36, N'Hungary', N'348', N'+36', N'HU', N'HUN', N'Венгрия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (37, N'Venezuela', N'862', N'+58', N'VE', N'VEN', N'Венесуэла', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (38, N'British Virgin Islands', N'092', N'+1284', N'VG', N'VGB', N'Британские Виргинские острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (39, N'Virgin Islands', N'850', N'+1340', N'VI', N'VIR', N'Виргинские острова США', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (40, N'Vietnam', N'704', N'+84', N'VN', N'VNM', N'Вьетнам', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (41, N'Gabon', N'266', N'+241', N'GA', N'GAB', N'Габон', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (42, N'Haiti', N'332', N'+509', N'HT', N'HTI', N'Гаити', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (43, N'Guyana', N'328', N'+592', N'GY', N'GUY', N'Гайана', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (44, N'The Gambia', N'270', N'+220', N'GM', N'GMB', N'Гамбия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (45, N'Ghana', N'288', N'+233', N'GH', N'GHA', N'Гана', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (46, N'Guadeloupe', N'312', N'+590', N'GP', N'GLP', N'Гваделупа', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (47, N'Guatemala', N'320', N'+502', N'GT', N'GTM', N'Гватемала', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (48, N'Guinea', N'324', N'+224', N'GN', N'GIN', N'Гвинея', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (49, N'Guinea-Bissau', N'624', N'+245', N'GW', N'GNB', N'Гвинея-Бисау', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (50, N'Germany', N'276', N'+49', N'DE', N'DEU', N'Германия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (51, N'Guernsey', N'831', N'', N'GG', N'GGY', N'Гернси', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (52, N'Gibraltar', N'292', N'+350', N'GI', N'GIB', N'Гибралтар', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (53, N'Honduras', N'340', N'+504', N'HN', N'HND', N'Гондурас', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (54, N'Hong Kong', N'344', N'+852', N'HK', N'HKG', N'Гонконг', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (55, N'Grenada', N'308', N'+1473', N'GD', N'GRD', N'Гренада', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (56, N'Greenland', N'304', N'+299', N'GL', N'GRL', N'Гренландия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (57, N'Greece', N'300', N'+30', N'GR', N'GRC', N'Греция', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (58, N'Georgia', N'268', N'+995', N'GE', N'GEO', N'Грузия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (59, N'Guam', N'316', N'+1671', N'GU', N'GUM', N'Гуам', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (60, N'Denmark', N'208', N'+45', N'DK', N'DNK', N'Дания', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (61, N'Jersey', N'832', N'', N'JE', N'JEY', N'Джерси', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (62, N'Djibouti', N'262', N'+253', N'DJ', N'DJI', N'Джибути', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (63, N'Dominica', N'212', N'+1767', N'DM', N'DMA', N'Доминика', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (64, N'Dominican Republic', N'214', N'+1829', N'DO', N'DOM', N'Доминиканская Республика', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (65, N'Egypt', N'818', N'+20', N'EG', N'EGY', N'Египет', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (66, N'Zambia', N'894', N'+260', N'ZM', N'ZMB', N'Замбия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (67, N'Western Sahara', N'732', N'', N'EH', N'ESH', N'Западная Сахара', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (68, N'Zimbabwe', N'716', N'+263', N'ZW', N'ZWE', N'Зимбабве', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (69, N'Israel', N'376', N'+972', N'IL', N'ISR', N'Израиль', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (70, N'India', N'356', N'+91', N'IN', N'IND', N'Индия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (71, N'Indonesia', N'360', N'+62', N'ID', N'IDN', N'Индонезия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (72, N'Jordan', N'400', N'+962', N'JO', N'JOR', N'Иордания', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (73, N'Iraq', N'368', N'+964', N'IQ', N'IRQ', N'Ирак', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (74, N'Iran', N'364', N'+98', N'IR', N'IRN', N'Иран', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (75, N'Ireland', N'372', N'+353', N'IE', N'IRL', N'Ирландия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (76, N'Iceland', N'352', N'+354', N'IS', N'ISL', N'Исландия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (77, N'Spain', N'724', N'+34', N'ES', N'ESP', N'Испания', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (78, N'Italy', N'380', N'+39', N'IT', N'ITA', N'Италия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (79, N'Yemen', N'887', N'+967', N'YE', N'YEM', N'Йемен', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (80, N'Cape Verde', N'132', N'', N'CV', N'CPV', N'Кабо-Верде', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (81, N'Kazakhstan', N'398', N'+7', N'KZ', N'KAZ', N'Казахстан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (82, N'Cambodia', N'116', N'+855', N'KH', N'KHM', N'Камбоджа', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (83, N'Cameroon', N'120', N'+237', N'CM', N'CMR', N'Камерун', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (84, N'Canada', N'124', N'+1', N'CA', N'CAN', N'Канада', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (85, N'Qatar', N'634', N'+974', N'QA', N'QAT', N'Катар', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (86, N'Kenya', N'404', N'+254', N'KE', N'KEN', N'Кения', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (87, N'Cyprus', N'196', N'+357', N'CY', N'CYP', N'Кипр', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (88, N'Kyrgyzstan', N'417', N'+996', N'KG', N'KGZ', N'Киргизия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (89, N'Kiribati', N'296', N'+686', N'KI', N'KIR', N'Кирибати', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (90, N'China', N'156', N'+86', N'CN', N'CHN', N'Китай', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (91, N'Cocos (Keeling) Islands', N'166', N'', N'CC', N'CCK', N'Кокосовые (Килинг) острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (92, N'Colombia', N'170', N'+57', N'CO', N'COL', N'Колумбия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (93, N'Comoros', N'174', N'+269', N'KM', N'COM', N'Коморы', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (94, N'Republic of the Congo', N'178', N'+242', N'CG', N'COG', N'Конго', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (95, N'Democratic Republic of the Congo', N'180', N'+243', N'CD', N'COD', N'Демократическая Республика Конго', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (96, N'Costa Rica', N'188', N'+506', N'CR', N'CRI', N'Коста-Рика', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (97, N'Cote d’Ivoire', N'384', N'+225', N'CI', N'CIV', N'Кот д’Ивуар', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (98, N'Cuba', N'192', N'+53', N'CU', N'CUB', N'Куба', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (99, N'Kuwait', N'414', N'+965', N'KW', N'KWT', N'Кувейт', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (100, N'Laos', N'418', N'+856', N'LA', N'LAO', N'Лаос', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (101, N'Latvia', N'428', N'+371', N'LV', N'LVA', N'Латвия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (102, N'Lesotho', N'426', N'+266', N'LS', N'LSO', N'Лесото', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (103, N'Lebanon', N'422', N'+961', N'LB', N'LBN', N'Ливан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (104, N'Libya', N'434', N'+218', N'LY', N'LBY', N'Ливия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (105, N'Liberia', N'430', N'+231', N'LR', N'LBR', N'Либерия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (106, N'Liechtenstein', N'438', N'+423', N'LI', N'LIE', N'Лихтенштейн', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (107, N'Lithuania', N'440', N'+370', N'LT', N'LTU', N'Литва', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (108, N'Luxembourg', N'442', N'+352', N'LU', N'LUX', N'Люксембург', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (109, N'Mauritius', N'480', N'+230', N'MU', N'MUS', N'Маврикий', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (110, N'Mauritania', N'478', N'+222', N'MR', N'MRT', N'Мавритания', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (111, N'Madagascar', N'450', N'+261', N'MG', N'MDG', N'Мадагаскар', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (112, N'Mayotte', N'175', N'', N'YT', N'MYT', N'Майотта', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (113, N'Macau', N'446', N'+853', N'MO', N'MAC', N'Макао', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (114, N'Malawi', N'454', N'+265', N'MW', N'MWI', N'Малави', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (115, N'Malaysia', N'458', N'+60', N'MY', N'MYS', N'Малайзия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (116, N'Mali', N'466', N'+223', N'ML', N'MLI', N'Мали', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (117, N'United States Pacific Island Wildlife Refuges', N'581', N'', N'UM', N'UMI', N'Малые Тихоокеанские отдаленные острова США', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (118, N'Maldives', N'462', N'+960', N'MV', N'MDV', N'Мальдивы', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (119, N'Malta', N'470', N'+356', N'MT', N'MLT', N'Мальта', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (120, N'Morocco', N'504', N'+212', N'MA', N'MAR', N'Марокко', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (121, N'Martinique', N'474', N'+596', N'MQ', N'MTQ', N'Мартиника', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (122, N'Marshall Islands', N'584', N'+692', N'MH', N'MHL', N'Маршалловы острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (123, N'Mexico', N'484', N'+52', N'MX', N'MEX', N'Мексика', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (124, N'Micronesia, Federated States of', N'583', N'+691', N'FM', N'FSM', N'Микронезия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (125, N'Mozambique', N'508', N'+258', N'MZ', N'MOZ', N'Мозамбик', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (126, N'Moldova', N'498', N'+373', N'MD', N'MDA', N'Молдова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (127, N'Monaco', N'492', N'+377', N'MC', N'MCO', N'Монако', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (128, N'Mongolia', N'496', N'+976', N'MN', N'MNG', N'Монголия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (129, N'Montserrat', N'500', N'+1664', N'MS', N'MSR', N'Монтсеррат', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (130, N'Burma', N'104', N'+95', N'MM', N'MMR', N'Мьянма', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (131, N'Namibia', N'516', N'+264', N'NA', N'NAM', N'Намибия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (132, N'Nauru', N'520', N'+674', N'NR', N'NRU', N'Науру', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (133, N'Nepal', N'524', N'+977', N'NP', N'NPL', N'Непал', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (134, N'Niger', N'562', N'+227', N'NE', N'NER', N'Нигер', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (135, N'Nigeria', N'566', N'+234', N'NG', N'NGA', N'Нигерия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (136, N'Netherlands Antilles', N'530', N'', N'AN', N'ANT', N'Нидерландские Антилы', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (137, N'Netherlands', N'528', N'+31', N'NL', N'NLD', N'Нидерланды', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (138, N'Nicaragua', N'558', N'+505', N'NI', N'NIC', N'Никарагуа', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (139, N'Niue', N'570', N'+683', N'NU', N'NIU', N'Ниуэ', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (140, N'New Zealand', N'554', N'+64', N'NZ', N'NZL', N'Новая Зеландия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (141, N'New Caledonia', N'540', N'+687', N'NC', N'NCL', N'Новая Каледония', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (142, N'Norway', N'578', N'+47', N'NO', N'NOR', N'Норвегия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (143, N'United Arab Emirates', N'784', N'+971', N'AE', N'ARE', N'Объединенные Арабские Эмираты', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (144, N'Oman', N'512', N'+968', N'OM', N'OMN', N'Оман', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (145, N'Bouvet Island', N'074', N'', N'BV', N'BVT', N'Остров Буве', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (146, N'Isle of Man', N'833', N'', N'IM', N'IMN', N'Остров Мэн', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (147, N'Norfolk Island', N'574', N'+672', N'NF', N'NFK', N'Остров Норфолк', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (148, N'Christmas Island', N'162', N'', N'CX', N'CXR', N'Остров Рождества', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (149, N'Saint Martin', N'663', N'', N'MF', N'MAF', N'Остров Святого Мартина', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (150, N'Heard Island and McDonald Islands', N'334', N'', N'HM', N'HMD', N'Остров Херд и острова Макдональд', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (151, N'Cayman Islands', N'136', N'+1345', N'KY', N'CYM', N'Каймановы острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (152, N'Cook Islands', N'184', N'+682', N'CK', N'COK', N'Острова Кука', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (153, N'Turks and Caicos Islands', N'796', N'+1649', N'TC', N'TCA', N'Острова Тёркс и Кайкос', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (154, N'Pakistan', N'586', N'+92', N'PK', N'PAK', N'Пакистан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (155, N'Palau', N'585', N'+680', N'PW', N'PLW', N'Палау', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (156, N'Palestinian Territory, Occupied', N'275', N'', N'PS', N'PSE', N'Оккупированная палестинская территория', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (157, N'Panama', N'591', N'+507', N'PA', N'PAN', N'Панама', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (158, N'Holy See (Vatican City)', N'336', N'+39', N'VA', N'VAT', N'Ватикан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (159, N'Papua New Guinea', N'598', N'+675', N'PG', N'PNG', N'Папуа-Новая Гвинея', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (160, N'Paraguay', N'600', N'+595', N'PY', N'PRY', N'Парагвай', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (161, N'Peru', N'604', N'+51', N'PE', N'PER', N'Перу', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (162, N'Pitcairn', N'612', N'', N'PN', N'PCN', N'Питкерн', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (163, N'Poland', N'616', N'+48', N'PL', N'POL', N'Польша', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (164, N'Portugal', N'620', N'+351', N'PT', N'PRT', N'Португалия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (165, N'Puerto Rico', N'630', N'+1787', N'PR', N'PRI', N'Пуэрто-Рико', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (166, N'Macedonia', N'807', N'+389', N'MK', N'MKD', N'Республика Македония', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (167, N'Reunion', N'638', N'+262', N'RE', N'REU', N'Реюньон', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (168, N'Russia', N'643', N'+7', N'RU', N'RUS', N'Россия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (169, N'Rwanda', N'646', N'+250', N'RW', N'RWA', N'Руанда', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (170, N'Romania', N'642', N'+40', N'RO', N'ROU', N'Румыния', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (171, N'Samoa', N'882', N'+685', N'WS', N'WSM', N'Самоа', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (172, N'San Marino', N'674', N'+378', N'SM', N'SMR', N'Сан-Марино', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (173, N'Sao Tome and Principe', N'678', N'+239', N'ST', N'STP', N'Сан-Томе и Принсипи', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (174, N'Saudi Arabia', N'682', N'+966', N'SA', N'SAU', N'Саудовская Аравия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (175, N'Swaziland', N'748', N'+268', N'SZ', N'SWZ', N'Свазиленд', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (176, N'Saint Helena', N'654', N'', N'SH', N'SHN', N'Святая Елена', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (177, N'Korea, North', N'408', N'+850', N'KP', N'PRK', N'Северная Корея', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (178, N'Northern Mariana Islands', N'580', N'+1670', N'MP', N'MNP', N'Северные Марианские острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (179, N'Saint Barthélemy', N'652', N'', N'BL', N'BLM', N'Сен-Бартельми', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (180, N'Saint Pierre and Miquelon', N'666', N'', N'PM', N'SPM', N'Сен-Пьер и Микелон', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (181, N'Senegal', N'686', N'+221', N'SN', N'SEN', N'Сенегал', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (182, N'Saint Vincent and the Grenadines', N'670', N'+1784', N'VC', N'VCT', N'Сент-Винсент и Гренадины', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (183, N'Saint Lucia', N'662', N'+1758', N'LC', N'LCA', N'Сент-Люсия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (184, N'Saint Kitts and Nevis', N'659', N'+1869', N'KN', N'KNA', N'Сент-Китс и Невис', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (185, N'Serbia', N'688', N'+381', N'RS', N'SRB', N'Сербия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (186, N'Seychelles', N'690', N'+248', N'SC', N'SYC', N'Сейшелы', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (187, N'Singapore', N'702', N'+65', N'SG', N'SGP', N'Сингапур', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (188, N'Syria', N'760', N'+963', N'SY', N'SYR', N'Сирия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (189, N'Slovakia', N'703', N'+421', N'SK', N'SVK', N'Словакия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (190, N'Slovenia', N'705', N'+386', N'SI', N'SVN', N'Словения', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (191, N'United Kingdom', N'826', N'+44', N'GB', N'GBR', N'Великобритания', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (192, N'United States', N'840', N'+1', N'US', N'USA', N'Соединенные Штаты Америки', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (193, N'Solomon Islands', N'090', N'+677', N'SB', N'SLB', N'Соломоновы острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (194, N'Somalia', N'706', N'+252', N'SO', N'SOM', N'Сомали', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (195, N'Sudan', N'736', N'+249', N'SD', N'SDN', N'Судан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (196, N'Suriname', N'740', N'+597', N'SR', N'SUR', N'Суринам', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (197, N'Sierra Leone', N'694', N'+232', N'SL', N'SLE', N'Сьерра-Леоне', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (198, N'Tajikistan', N'762', N'+992', N'TJ', N'TJK', N'Таджикистан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (199, N'Thailand', N'764', N'+66', N'TH', N'THA', N'Таиланд', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (200, N'Tanzania', N'834', N'+255', N'TZ', N'TZA', N'Танзания', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (201, N'Taiwan', N'158', N'+886', N'TW', N'TWN', N'Тайвань (Китай)', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (202, N'Timor-Leste', N'626', N'+670', N'TL', N'TLS', N'Тимор-Лесте', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (203, N'Togo', N'768', N'+228', N'TG', N'TGO', N'Того', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (204, N'Tokelau', N'772', N'+690', N'TK', N'TKL', N'Токелау', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (205, N'Tonga', N'776', N'+676', N'TO', N'TON', N'Тонга', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (206, N'Trinidad and Tobago', N'780', N'+1868', N'TT', N'TTO', N'Тринидад и Тобаго', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (207, N'Tuvalu', N'798', N'+688', N'TV', N'TUV', N'Тувалу', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (208, N'Tunisia', N'788', N'+216', N'TN', N'TUN', N'Тунис', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (209, N'Turkmenistan', N'795', N'+993', N'TM', N'TKM', N'Туркмения', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (210, N'Turkey', N'792', N'+90', N'TR', N'TUR', N'Турция', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (211, N'Uganda', N'800', N'+256', N'UG', N'UGA', N'Уганда', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (212, N'Uzbekistan', N'860', N'+998', N'UZ', N'UZB', N'Узбекистан', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (213, N'Ukraine', N'804', N'+380', N'UA', N'UKR', N'Украина', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (214, N'Wallis and Futuna', N'876', N'', N'WF', N'WLF', N'Уоллис и Футуна', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (215, N'Uruguay', N'858', N'+598', N'UY', N'URY', N'Уругвай', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (216, N'Faroe Islands', N'234', N'+298', N'FO', N'FRO', N'Фарерские острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (217, N'Fiji', N'242', N'+679', N'FJ', N'FJI', N'Фиджи', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (218, N'Philippines', N'608', N'+63', N'PH', N'PHL', N'Филиппины', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (219, N'Finland', N'246', N'+358', N'FI', N'FIN', N'Финляндия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (220, N'Falkland Islands (Islas Malvinas)', N'238', N'+500', N'FK', N'FLK', N'Фолклендские (Мальвинские) острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (221, N'France', N'250', N'+33', N'FR', N'FRA', N'Франция', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (222, N'French Guiana', N'254', N'+594', N'GF', N'GUF', N'Французская Гвиана', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (223, N'French Polynesia', N'258', N'+689', N'PF', N'PYF', N'Французская Полинезия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (224, N'French Southern Lands', N'260', N'', N'TF', N'ATF', N'Французские Южные территории', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (225, N'Croatia', N'191', N'+385', N'HR', N'HRV', N'Хорватия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (226, N'Central African Republic', N'140', N'+236', N'CF', N'CAF', N'Центральноафриканская Республика', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (227, N'Chad', N'148', N'+235', N'TD', N'TCD', N'Чад', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (228, N'Montenegro', N'499', N'+382', N'ME', N'MNE', N'Черногория', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (229, N'Czech Republic', N'203', N'+420', N'CZ', N'CZE', N'Чешская Республика', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (230, N'Chile', N'152', N'+56', N'CL', N'CHL', N'Чили', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (231, N'Switzerland', N'756', N'+41', N'CH', N'CHE', N'Швейцария', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (232, N'Sweden', N'752', N'+46', N'SE', N'SWE', N'Швеция', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (233, N'Svalbard and Jan Mayen', N'744', N'', N'SJ', N'SJM', N'Шпицберген и Ян Майен', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (234, N'Sri Lanka', N'144', N'+94', N'LK', N'LKA', N'Шри-Ланка', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (235, N'Ecuador', N'218', N'+593', N'EC', N'ECU', N'Эквадор', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (236, N'Equatorial Guinea', N'226', N'+240', N'GQ', N'GNQ', N'Экваториальная Гвинея', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (237, N'Åland Islands', N'248', N'', N'AX', N'ALA', N'Эландские острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (238, N'El Salvador', N'222', N'+503', N'SV', N'SLV', N'Эль-Сальвадор', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (239, N'Eritrea', N'232', N'+291', N'ER', N'ERI', N'Эритрея', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (240, N'Estonia', N'233', N'+372', N'EE', N'EST', N'Эстония', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (241, N'Ethiopia', N'231', N'+251', N'ET', N'ETH', N'Эфиопия', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (242, N'South Africa', N'710', N'+27', N'ZA', N'ZAF', N'Южная Африка', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (243, N'South Georgia and the South Sandwich Islands', N'239', N'', N'GS', N'SGS', N'Южная Джорджия и Южные Сандвичевы острова', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (244, N'Korea, South', N'410', N'+82', N'KR', N'KOR', N'Южная Корея', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (245, N'Jamaica', N'388', N'+1876', N'JM', N'JAM', N'Ямайка', 0)
GO
INSERT [dbo].[Countries] ([Id], [EnglishName], [ISO], [PhoneCode], [TwoCharsCode], [ThreeCharsCode], [Name], [IsDeleted]) VALUES (246, N'Japan', N'392', N'+81', N'JP', N'JPN', N'Япония', 0)
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF

-- END CHANGES

-- Start writing new version info 
GO
IF @@ERROR <> 0
BEGIN
    DECLARE @errorMessage VARCHAR(MAX)
    SET @errorMessage = ERROR_MESSAGE()
    RAISERROR(@errorMessage, 16, 1)
END
ELSE
BEGIN
    DECLARE @newDbVersion       varchar(11)
    SET @newDbVersion = '0.11'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, ''
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info