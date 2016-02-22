-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.33'

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

ALTER TABLE [dbo].[Products] ADD [ShortDescription] [nvarchar](100) NOT NULL DEFAULT ''
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201602220813442_ShortDescription', N'OS.DAL.EF.Migrations.Configuration',  0x1F8B0800000000000400ED5D5B6F1B3B927E5F60FF83A0A79941C6B29D938333813D03C79773BC278E359133D87D32DA126DF59E56B7A6BB951363B1BF6C1FF627ED5F58B2AFBC54F1D237498E1120B69B64912C7EAC2A9255E4FFFDCFFF9EFCEDDB2A187D2571E247E1E9F8E8E0703C22E13C5AF8E1D3E978933EFEF9A7F1DFFEFAAFFF7272B9587D1BFDA3CCF796E5A325C3E474BC4CD3F5FBC924992FC9CA4B0E56FE3C8E92E8313D9847AB89B78826C787877F991C1D4D082531A6B446A393CF9B30F55724FB83FE791E8573B24E375E70132D489014DF69CA2CA33AFAE4AD48B2F6E6E4747C3B3BB838FB787079351E9D05BE471B3023C1E378E48561947A296DDEFB2F0999A571143ECDD6F48317DC3DAF09CDF7E80509299AFDBECE6EDB83C363D683495DB02435DF2469B4722478F4B660C9442EDE88B1E38A6594699794B9E933EB75C6B8D3F187D80B17E3915CD3FBF32066B932A67ED8247E4892E4E08266F1C383ACCC9B919AF2A68201450BFBF76674BE09D24D4C4E43B249632F78339A6E1E027FFE2B79BE8B7E23E169B80902BE85B48D344DF8403F4DE3684DE2F4F933792CDA7D4D1B3D11CB4DE4825531AE4CDEA9EB307D7B3C1E7DA2957B0F01A900C03160964631F9998424F652B2987A694AE290D120190B95DAA5BAD8FF656D147174CE8C4737DEB78F247C4A97A7E3E37774965CF9DFC8A2FC52B4E04BE8D329460BA5F186002DD4D77A9D5C9080D0F696557F88A28078A181D0C9A4C685162D7436A6DE3CBD0E1F2347CC70255F91A3AD8B718AE6D48087FE6A059EED6385F6A3F8C1121A404624F08A1C1BE4B0EACCD55A916A4BA621C628A14FDE57FF29E30A363D3E93204B4F96FE3AD7F42562EE55E42474C2C4D1EA7314D424A06CF7775EFC44D8E48BCC7967D1269EBB373D9F0A78F359BA6517B0AC5837D0FC50575C677AB3E9FD3AA70D137151DB111C482EC3CDCA793AEE9551623193C4D9D18F402867868D4028675D9B59D45C51BE6AC8C6B3897D799D510E33AA0B1D85CC2CA34E6B38BB36611A3F3BCFACACD4EBACD2D675193E057EB234CC859EA6C2EC5653E75BA9CABC8A76354E9751480441D2D70AEDEEF7E87CE9C589A1B2E31E3A79B78C09B1A9BC0F0E6F07483D2F87AFFCC055AFB322AFA2475B1763915107BFEB602E5E78A95721C30F3DA64A6C26FC0E2872508F33C6015A96D7DF4816456F63F95AE96BDAABC5669E52619BBA6E35F245BB9C3EA30F5E4238DB319BD186E1BDA1F5F524506EE305891D599395791529FA35424C3C6E46D2894FEEFC95BB42395BAF29BBB2267D49485C7701905147C73F6D6F4757274DA44E80A22403D5BD92B316246006458CC0B92021A26B7046858E7A2E03E0358C98E7BE9848527BA57465470DCCE4BA2398959A51DC6E1292FCE2D399CCF40ACA6338BBCC682817C26D30AB2BCBA75472B0B349B4D96506B9A1F977A46945622B25A260D249584AA5F75A6CB690398E62EF92F225D09A633F7620EAB25AA8B1F1E8C7AB06F24E46B09724BF47F1E2172F59F6BEAA9B91F926A638A5D36EB5EEBDB66CB5FA69B37A60F01FAEAECE8686AE81AFBC39954B97212BD59ADEC768FE5BB4492FC30553EC5FD2B9AAE72D0974D29CB3F99C4A932B0A66B2C8369BDA9DB73139655C0ED9CDBFE60B90C0F357B0E295957B99B5560C700E454520D95C35D7C7E8C90FED9A5A66C59B9AE73036B5C8D6A192956B50D52D9CC3D8548D0AD6359511B3636A91136F6896C1D8CE3C572B4BA15C1C307A199874B6C24DE56E7596AC3F91F4A02C7D90D3BD8A294DAA4F7E3B50C8BE195917AE6D8B635BDBE2EDD1C3E3DB9FDEFDE82DDEFEF80379FBEE252ECF3A5B4BB97A44B0E1CBB7487A56A3594DFFF0824DD755359A0D99BCEA7E366464777F3664CDA49FBFFAD91A71622E5166A6E4ADF29778769D7352CB869E0E423787AE7C181960BF5759285CB75DCAACD05E2F2A87D8DE8F93B4A3FD7DD78582B7AD9A6FFCC562A0530DD3627DFFD6A07D1FE3F13A8CD99DDD6B464675F71523ACB6C0ACAC434D04CDB62CBDB2BD3BA25DC48DE626073E55E1576D63B2691897DA3A3DFF7DE315D5B5A1328DFD39394BEF96D9AED4EDE394AE81975E52E9840B32F7571E15DED398FE56C468515CCEE61EABC3BDC20C2A3BE8F05D1CCF74758E039E3660873DD6BB33E5E434B7B2CA8AB6B3FC696869F9B38B63F66627ECAFE244EF32429279ECAFF3C0BDBE4D2C262D7A130D59C05F5BD1305B46716AC793A3C35E5CBCB663CEF720128BA04D40D89442A1C851CB182141112D62AAABF43BA7D3E3298A7D64D7B7205EE47A2E055702344FC9A31CBBA319DD837132D7DEBC3CA2604AB6287955BE4A59500ECBF99C350DF36AD2F2F9BECCA236324F41DB562477A150CAF169A658CAD2AF0AC6706C1D43317A5D68A5A3C3E31F3A504B2F46E29E2FFD60E128E79432B8B893B2623314CDEF2C4532E4F4DD0B93ECC67AED6875F7A0754CFC57D453F3957DEE7D55F85E5DA7447BF288ADF01522AF92536F8B66FC1222C1383EBA9F0D76E432BACD25B8F30E68F7BB9FFBB1F3B92F8E78DBF60362DBB7B068E6C7FBBEC8560B65355511C740965682F8C3E6D9D93B342BF32A66F5066A76C6B9837B8A1A6FAA6C5C011F2AFEBB024821D10D8A9B9510A5CA05F75F275781F754DF4ED524269C51EA3406E64B485554F04CA5093FA422DB6F083BEA2B476FE53DD1C667FE2C54D6A96CC91960660AFBD21D634A6ADB65CEBF4D2F7FC67823E79D7EAAB31E3760A360E0B462214769BBECBB5D93B0E2C9A19E7DD74C063CC5B499B60C3F8F56EB42EEC06C970B7C26FF49E67CFEB7A6FC49147CE5F2FF60685010255CEE773620384B9268EE67632A4E27307A5FACFC325C8C1C2EC8A86DE9EA42981B3AEE3E73D6A4A28FF15B5669B7612EDA4767F3FC7ABC732F997B0B5592D3BE2D9A34AE5A822A8D13821EC576FE49A99EAA5CC256CCBEC7820E128A613F4C55FDEC87737FED05F64C9348582A79C68FAA3239E582D049C1F4B33D776C5AC15D08A536A6AA531A3413DB4E261C3CAD509B059636402E564E835E0819FD22186DE40EA0D8C4C0E1906CE292039A59B9AD211A8BC0C640620CC7AEC191DF35608283997423DC1D1E1C28569E3553900811ACE1A67091BADD4A28E02013DB10A7C2B50F0840E8653AEB3936C02CD6B3C4A601A8EBD910B316890BB205801C24B46B0095A2931080163101830054E4D816002AB264EF005AEC64D80240DEE0B006A84EBF1802CBB84ACA7D971E554A1E7466DB5429026DD7E6AB18FA864CD77CA77E90D92AB06B0B9355E0C7CECF55F8E60C6CEC0DD7684847592EF3537FF5863DE8D579DA1457DA160D802B2DAF6DEA076E7FD91EC4641F592D0E50875909609C4BBA23D2D0AB550C10EE54A6368725D2FCA150898C8F4DF5D5F9F256A028FA266208411C153913C11D75B07B2347B37097DC35B881ED1E0067E018D8D45B390A6F1360A8EB92011E666F2C0584B59BA38522B4AF10328CF5157664CE59726238089A5864D392DA4D7227505939A2D9A243F54A6B010B8B6A70F419C837D005B267B54982A36ED69DE807CC395BD8FF2CEE91EE70852A396E9B5A297B711BBB6E278D64F76F956E71196757184002A32C4DC7F2679FE669F9D37E466CDF66D077617823551A272B815DC7616E71590E5EB6A85F41EB6F5E1C727563D5326CDD05B824F7626D989936D84A5FC79FDD5F5909D76CEA8180EFEF36DC351A742F17F01CC55AA7732355B749A12DD29E26A4C67975F8FD5B9C4B034C3D9C133695C3D74A0C34E3042F516CA46197516ED721773BB69F71A09BA971C66DDF2681DA3D00BE20FE5BD91F95DBF200D8CAFD82993F052D51B9FA49A10E170F99C3C53728509F4E9CC25933297CF665F830523392F27B34C978543B248B9B600AFAC4E2E7F5439E10112ED98A94ECC70553943D4EEC086BA8D9923034CAB2356CC9E823748AE5A48106F3D081CAE79E3E86C299A2864A172ADF50BC88D0504A2B8741063A8A8B0B4414F08371205BDED2AA255B782F18C8E64200A2554A59877615179D6A9B956B799BA1E4AFB787C7945BFC9ABA89537224C1C78862B4EA7D2A9B7E2AEB10B4BFC08AC550816944AC46235330A028CD35BB549CD3008AA0811F53E34A58BC68282B2B37FFEDAA73BCFC5414A09BDBB54A53EC9F6C6E881CB2E71EEA168C73D0CE9318EAB1D19758ED35D85D27DA8371147D1848E5A49507ABD04B930F2BD7BB42E3695866F25AED9D55D875E62AA76CDC5A85BE191C5BB9AE15DA59C32783132A470BD2D09D73A9D4D1662E41BE95DA9E49DE95ADB8247942225C2A3BD339974A23C3CC256811AAED99B4206DC525692DCAD1AAECA7CE5953A86E3367004F3F6D67445FBF567C11FDF210F0141D69CD20E40126954116FE66C00E1FE671C6F5AA5C616838A4F7313331BB295794DB0111A6683DA4744744A28F94CC12DE5237F106F38A32B2B9016F44571C80291A5F1DF0EC50F4D6E1C5804DFF61FF1C8E4AB967D155C7F1DB6D5056D8799540DD32FA95A8ECE25B64E69BD18FC4A5820E985A8FB9999BB03784B6978A3F4467FC535C202C80DC62F629D7CAE1F350EB2701CE25CC53A2E9DCC47C23042BBBDAE8EA8C47E56576386B20AF09B00792DF445346486E12A6254B7BCD55EDC3187517E842A1D334B2134537FA4B769BE86716E99E44C44C1FF399BEEBA97E1323487B182F138436C13AE21DBEC6C00F94CD47CA4D3832C43202BA7548EDB9E984D9F68C99EB0268E6DB1E09F7BC74106FBB51D9819F739A4F3A79FBADD828D5F0003CDB6C0584F2CE9DEA6CAD4A3B99CCE64BB2F28A0F27139A654ED6E9C60B6EA205099232E1C65BAFFDF029A94B165F46B3B53767DB767F9E8D47DF5641989C8E9769BA7E3F992419E9E46055DD63368F56136F114D8E0F0FFF32393A9AAC721A93B9802DF924B0AA894E7CEF8948A94CDB2E48F63E0A7B9AFC21BB19FE7CB152B25D622789C8D67659AD7058A80E5BB9E15D6667BF17B265767071F6F1E0F2EA005C3CD43CA46D7A5A5148673D24B2B5AF96A325D90DD65E3C556FB43A8F82CD2AC44F8DF1D2F935697CF9FC8B3D05EE7E2AA119F56795D6C944628272D0ACB05839991707CC6A3885C3DB6683CA1FF0BA0FADB6743F035C9DF8F2249063E01734CCE6630DDBD1D6EFEE5B0EBA8948AF635FDEF3012000BB02C44813A1E7466BFF30D51248CDD1331C6416441E59D5334A47E1BBD328DDC89876C26558A9F20A11278894DB424DF191FB4835C10652B21F5C5C864F819F2CD5C115121CC678762B35877DB02F9FBDBBA78295FB6C4FEBEEF7E87CE9C5894A4E4C71A0B88C09C1684A69AF330B9C59F986A3CBACBA4ED8EFB78F7FA8A71723F2C706932B733D1C6866B1BAD491ADBFDA53628B65914AFE65B7F1612D2B85483DF731E58B2BC0EA6B70AF931B8F39648ADCCCBFEDCC542BB6329B8D0A78A66C311C48B99EAC9AF21103C1B0293FDAD3016E3EE1295A5C8CA283CADEC8666CEFD8062F060F0D0BE41829F46401E5EF090BB64FFEC99106B5EA1FFD78250FB49CE6600B7949F27B142F7EF192A5640E0929F6146764BE8919BF536FB516494A498E165BF952B262B395098DE8211C857338D98557DE9CA2EF326437F12F14DB504AB5A7FC319AFF166DD2CB70C1DE53F992CE45D2407203DA409BE53407C9379F9324B9A210258B6CE921493E35D99E369BC5AA05547FDD19B907F8903613826A2488BB18B4A0D18F2084349FBBBACB9A9C7B5F0B4AB9FEEC482BBB391E20567CDF4910A15EC0AE20CAE37EDA8108A181CB199A9D7EFBEA2F64892E2539C8F4A2CCAFE45912E57C425F50DD1220CAD3DF86AB22F0FCDA663D8414EC6B951B2729B4CCAD3E3B68380F22557FB5A774E32F16D0EA9BFF3EAC85D8B595B447AB0AD507A4BD5CCC42DDDA89459844BFCAB18CFFE7A96077026C77DB80F3A26BB17F50C77436DC48D010E8479E4DEB7B7C243D855DEF83D3FAFBC6CBBA2392AABFBAB4CA9F93B3F46E99BDD178FB38DDC4F365EE3E233412CB655F5375290C4F18BD2946330AFB239F5A02BD39C20786B6F08AB2B09BCC2738821240A00B8DEAF24D9E0A7A23274E67B68CE214EDA09AFA7A38A39B0ADA481187395185CE379E1B38859EC47F75EFA6B8DD86DDC68953EA7AB67D5738C4BCC85B9822EA750B0D4D120B42FD60B37C0751906CC5B7E18F4CBE4343A18BC54BCB858BDBA265282FE32D8D47E1A1DF6C40F2EB4EDC470229D7933AAA6EF512D4117AD797A61D3B38CDC42808D54D04BCD2031A4B34B38DFF078BE7005C3734B774A88CB21A7A80207C5F1BD7A0E66D45EF8E6B0C536DC368D50B3FBB6CF03A614F5C57AFF43A73408E8E7186CE19722D85C5A97595D7F16C1A181798724B0815443A800DD2BC5D440DDAE9D6489116195C10B8C5A286CB6D58BC20EB7C6054B02A5A8E8B4CB603FCA02D6D09F0220CD7AD855D01418D6ED7E040CD6CB9BF8373130B586FAC70446ADD0D3B16A9BF5372C3DCFDCE705346FCEBE052E671F25FD40C817835C0A0F3CDA65DEDA0DB9326417BDB1A0962743ABA0B811A18E8153ED0B27BD78C0928A67EB706BEB909A14464CB59AA5552F1A5FABB8AC82EA2A18530ED8C1F2CE83AE343524466CBE1D17996F1A87493381DCF9E9394AC0E588683D93F83F3C027CC29ABCC70E385FE2349D2BBE837129E8E8F0F8F8EC7A3B3C0F7923C38BE08FC7E2FDFC86C15097EF496458293C56A2217778F27675492641100D1E46CF2F0C70352D4F7AF44C140890DDD2DDC2713B9E00900C5FC3E549FB1349BA13F133AE26C6B6CEAA52989C37A27663C626863FE7615E2265AF2F9E6495E41F8D5634773317035F675B820DF4EC7FF95957A3FFAF26B7EC314FBEB0D85F897D0FFE7867EBF8B3764F4DFE3D18DF7ED23099FD2251DEC7787CE8DE2D6FF79CB1EFCD440845FF56B070F8D9BDEDB21AC22B0C551FCC3CAFBF6479E5876A3F996394F34C1CBFB3E006500345793691E5DFFFBBD50F8CD28535AEF47876C16356B46E326B4AC7E00E8BC18BC2C88504127327BC765EE4B9BF2DFDD100201C07B3B7C42187103E3A7E00647C6600535194D16A25CB4CDB561B42C43A8A1516F9DDBC4053C77606C88F1CE0DBBCA133199A2CEFD95A3A79BB65120D3F9A8B485714FF8ED511AA927667B2B8AEAD06BAD3678E73AB9F260EC9C2625F9E0875EFC3CD49A00354EE543B64686AA4804335AD5AE59C30BD8F6DA5B7C554E34791D0BFA47EA33B839D201A28D5D250E1D41858A387A1CE48F8E7FDA0A50B94D39377056057B00A4F6A07708688252491A223BCB2B0F51D1CABA1F5D075E0E666E31FA42087307368E14C0DC01452134A75B7A9DB0508D546E4E0B084DC6C5984D67E590E4E64D0362909B2F07EBE863672BAE28997D366EC5FEF832C4A12118796F75750BC5EAA64DED2C873A38BA0331C347473B936B840C20C2D80E19868062F89D753C6018C80FC7E899F127B5AC63DD2CF4A263DADB84B6357AA6D02BC4FB2A4CB86067FB95A59D56F67A22CC074277BB1A06CDCE9D30BFFADC26D10716DB211B0B27B67E47DC3C11764BED95BD68D09ABCE810924A1786BCB7126B5A87333BDA9A65C156079875087473431E0F762ED62D64EEAFBC80B9C6D0DF92CCC7E588A282792191263BD4556C931BC78A623B7BE0FBB2802D045776A183F280E69E2055053ABB41AA28D60A526A48B4CE0C3D743F94687C545200D2E2A8A489E1D3D116BBEA59ECBABF2E53E861F13ED5C550EFED14AF83B11D58CE70F5F9F6E2CBF9DDF9D9DDE5CFB79FFFE37E7AF6F9F2D3DDFDF5C5FDA7B39BCB8AFD4710E81C0F84ACA7D5F10FAEB49B4F2BBBEE1FEFC69C7333CF0C21D97B0BF532BABBB995D4D599D40B357EF0B0EABD3AEA69261458A7BBDBD0B6E6391040BDB713745A456237D9B2DFE18921990E2D1609539BD843B41818B2611A74A8CA46CB5C8E42AB91E23BD3A8216E0D701D6528F46CB02969C1841DE6BEDDBE63FE2E40DB49CA452A89AE3E80B78E3C9AF59B95520C43F66266F5ED6613A43E7380A0D55355A4C4A3DD86B9C8199DCDF3A8A1732F997BEA6B2759C496A105CAAD0E62638464B15D7F52AAA388246C55E07BCC39214963CA70E5B60ABA960FE7FEDA0B244E48F92C81CE3A595194532EC89A844CA9E05DB6A955F33EDBC9A4AA43E2BC891742C89B15BE32F7AF0618C386161AD3EF036BD623BF55BCB1FC5BC31C76974B6F237C787070A40C724D3F7380E529E61FFA44C9C060811F45C2E161BEC0660098C8F79740D7F673A328BBF5F103AAA40D229954CF1ABE4D406A2F8833BFDAD239DC6CDE4870381CDD06D8A0EBFDF7066CB9B30E06B622F525820D7B4B61C7C106BACAD4433BE5AE9C28C6B3FCE4A4E75A80B62378401DED07154D8038D5DD96B10558009751EE8D08CAB65B31099427BE440184DCFDB963F227BFCC451F07D109D00C02290F0DE2E9155F5E0A34B01716D58A2CDE1F1C0E1A952FD43D14BCE53C7E3D891BC96D4B690697D40B9EEC07B70B14E9DED9506B446F691E0444257AA0BB7DEAF1CB53F9612BBE0C821E0836FDE205E0463F7871010AFA10C39040A90E61CE977EB0C09E265007AF727B0106B14E73524952E9FC422D7BEA5DD9C9C6C715FA028DD0712BA3197D38612B089AEAAE53ED0641FD0A24F93C56D3B07EC5D5F631E822C7ACCEA0B70A48E826C766FAE8FB02E07E006FEB8053EE2AC686B9BC7C483C4229BE35D195039A50E0C549BD42C2F2D4C4E616E6E1576FB04FCF2EC99C6DAFE10694310D567153FC49C201F78938FF5B527AE0EEF29680EA2AAC3407C8F202B6086CDEBFDAB5AD02E1CA6C544E75740032EC7EE370871DF630DBF61107EF8D9DC59BE26B7CC1711B3A49804E115EF0C986E179B1DD38D6C05E3A1E045C99DB7967B2A42728E5BEF1C2AE67FE65CF6510F6D81A2683B6BD5ECA3CA2EFD930D404EFAFE268759FB9A7DD45F77C465C4C59398F59ACA2F8F7454453BC4CB150758D3062ED1CD6CD8A0A7E05C5A1C201D7D486B177583FD92DA55D41B07FAB2077100CBCC172293E0552ADF0A5673B144C14CFBCF0C72AE3D165E5E52F9E70E58F7E9C8E170F111DEC3C4C204B52DE795528F34F2EA8F48554A8162E835D5DB2672D58A59C09AB9948DEE5960DC06BD556654D5FDF3363976CFB52ECB101F51429701D2CD1B7A820573C0AF5FC33449AA598C9164B24856EF11D229C2599292BCE234A1D4A0EA8B6B364FD89A4F962C25425E074AB540AE4D1575B3826BBD45DF8606AEB2EF2E8EB2EFC544D759726AE52619900D53225D13A50AD5B5DBFF2F58FB65B79167DAF72CF372B64723B843044B90C2856AB3C169C446BD356E34ABF3E7CC4EAA97368EAE3CED2ADB8096C8CC15C0532A2DC055E79B7C594014F262CD9E1A85880A9CA3AFF0E2AEBFC5D6AC7C1346247C9681EDA675764959624D686EA1143BCEA328B54A1F8CE9A4500E3882B21EA5C732C9A74A625D809D9737BD537C568D44716A924846479A92F76DA9E2168C41DCE14BB203DA88358CFA02E6D9D41E853DF2A63AC22C9BAED10B0F8E7CAE71F5AB300097D023860132425341931BAC027B0755D472DA98C1290DA39534AD3C7CC142898A777A608269EC29422B573A694F69C9929F0D620B053CAF5A0FCA461410B5676D0FD42E19B7B0FC456F48E08DE9851009127B66608ECDA0F30C42206A0178608CB49EE5DDC8EBA2EBBAE633DD7BAB83769B05A465999D485B9A4D6DD169DAD81FE6ABCB1C593097ECF2A6B6BF145D351A8879D770D750FC63B6BE7510C75455E78F15DAAD3CC2C113D88ED6975C026D907D6824D5AB7D921D8A4019292A53F86153E9A2E0C831FE86E3645768D418A4FA146BA68DD0F25135CD8082DECEEE2DBD6640DE23A67D61FC8E149070818528B685CBD50E3C1EC18D68D224537A56A2240968E58821BD4B8EB520766747F6612E0820374CEE4A8031AB9A8810B19B75B3593055711A0FBB82B4907632BEC37E68656FEA52BB9EDEADB808BF5565E12EE5B25BA3371557822DB90CDD59D911DA0434097DABEC3CE9677CC5547D955DAC924DFDB2D3ED03FA9D4F49EC84DB42041927D3D997CA60AD95FE5B7D39D5C90C47FAA499C509A21990B47E7551E76B45C9EE24B2D2AB394C905FB6F48EA2DBCD43B8B53FFD1A35D8D23F61C981F3E8D47D92347ECC99107B2B80E6F37E97A93D22E93D54320580BCC134057FFC94469F3C96D767F73D2451768337D76F3EE6DF86143171C55BBAF80BBFF1012CCC5A0B8B7948D65CAEE2F7D7AAE287D8A424B4205FB2ACF883BB25A079458721BCEBCAFA449DBA8E4FD489EBC3933EF8AE7923022E68110D97E72E17B4FB1B74A0A1A7579FA27C5F062F5EDAFFF0F46EA5382F7550100 , N'6.1.3-40302')
GO

DELETE FROM Products

GO
SET IDENTITY_INSERT [dbo].[Products] ON 

GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (1, N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ', CAST(250.00 AS Decimal(18, 2)), N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS', 2, 90, 0, N'Вентилятор настінний • потужність: 45 Вт • кількість швидкостей: 3 • діаметр: 40 см')
GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (2, N'БЫТОВЫЕ ВЕНТИЛЯТОРЫ MAICO СЕРИИ ER ДЛЯ ВАННЫХ
Производитель специализированного оборудования Maico – традиционно очень востребованная компания в Европе, ее продукция считается качественной и надежной. Вентиляторы, выпускаемые с производства, используются в быту, в производстве, устанавливаются в офисах, мастерских и прочих помещениях. 
РЕКОМЕНДАЦИИ ПО ПРИМЕНЕНИЮ 
Представляем вашему вниманию вентилятор Maico ER 60 центробежного типа для вытяжки воздуха. Данное устройство предназначается для небольших помещений и устанавливается на стене или потолке в ванных комнатах, санузлах офисов, квартир, коттеджей и т.п. 
Модель выполнена в стандартной комплектации.', CAST(5250.00 AS Decimal(18, 2)), N'БЫТОВОЙ ВЕНТИЛЯТОР ДЛЯ ВАННЫХ MAICO ER 60', 2, 60, 0, N'Витяжний вентилятор • тип виконання: настінний • витрата повітря, м3/год: 78 • рівень шуму, дБ: 26')
GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (3, N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ', CAST(250.00 AS Decimal(18, 2)), N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS 2', 2, 90, 0, N'Витяжний вентилятор • тип виконання: настінний/стельовий • витрата повітря, м3/год: 195')
GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (4, N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ', CAST(250.00 AS Decimal(18, 2)), N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS 3', 2, 90, 0, N'Витяжний вентилятор • витрата повітря, м3/год: 180 • рівень шуму, дБ: 35')
GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (5, N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ', CAST(250.00 AS Decimal(18, 2)), N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS 4', 2, 90, 0, N'Витяжний вентилятор • витрата повітря, м3/год: 180 • рівень шуму, дБ: 35')
GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (6, N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ', CAST(250.00 AS Decimal(18, 2)), N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS 5', 2, 90, 0, N'Витяжний вентилятор • витрата повітря, м3/год: 180 • рівень шуму, дБ: 35')
GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (7, N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ', CAST(250.00 AS Decimal(18, 2)), N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS 6', 2, 90, 0, N'Витяжний вентилятор • витрата повітря, м3/год: 180 • рівень шуму, дБ: 35')
GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (8, N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ', CAST(250.00 AS Decimal(18, 2)), N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS 7', 2, 90, 0, N'Витяжний вентилятор • витрата повітря, м3/год: 180 • рівень шуму, дБ: 35')
GO
INSERT [dbo].[Products] ([Id], [Description], [Price], [Name], [BrandId], [CountryProducer_Id], [IsDeleted], [ShortDescription]) VALUES (9, N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ', CAST(250.00 AS Decimal(18, 2)), N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS 8', 2, 90, 0, N'Витяжний вентилятор • витрата повітря, м3/год: 180 • рівень шуму, дБ: 35')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (1, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (2, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (3, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (4, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (5, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (6, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (7, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (8, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (9, 4)
INSERT [dbo].[ProductCategoryProducts] ([Product_Id], [ProductCategory_Id]) VALUES (1, 5)


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
    SET @newDbVersion = '0.33'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, ''
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version infon