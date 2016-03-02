-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.34'

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
ALTER TABLE [dbo].[Brands] ADD [Created] [datetime]
ALTER TABLE [dbo].[Brands] ADD [Updated] [datetime]
ALTER TABLE [dbo].[Brands] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[ContactInfos] ADD [Created] [datetime]
ALTER TABLE [dbo].[ContactInfos] ADD [Updated] [datetime]
ALTER TABLE [dbo].[ContactInfos] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[ContentContentTypes] ADD [Created] [datetime]
ALTER TABLE [dbo].[ContentContentTypes] ADD [Updated] [datetime]
ALTER TABLE [dbo].[ContentContentTypes] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[Contents] ADD [Created] [datetime]
ALTER TABLE [dbo].[Contents] ADD [Updated] [datetime]
ALTER TABLE [dbo].[Contents] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[ContentTypes] ADD [Created] [datetime]
ALTER TABLE [dbo].[ContentTypes] ADD [Updated] [datetime]
ALTER TABLE [dbo].[ContentTypes] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[Countries] ADD [Created] [datetime]
ALTER TABLE [dbo].[Countries] ADD [Updated] [datetime]
ALTER TABLE [dbo].[Countries] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[Files] ADD [Created] [datetime]
ALTER TABLE [dbo].[Files] ADD [Updated] [datetime]
ALTER TABLE [dbo].[Files] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[Orders] ADD [Updated] [datetime]
ALTER TABLE [dbo].[Orders] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[People] ADD [Created] [datetime]
ALTER TABLE [dbo].[People] ADD [Updated] [datetime]
ALTER TABLE [dbo].[People] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[OrderedProducts] ADD [Created] [datetime]
ALTER TABLE [dbo].[OrderedProducts] ADD [Updated] [datetime]
ALTER TABLE [dbo].[OrderedProducts] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[Products] ADD [Created] [datetime]
ALTER TABLE [dbo].[Products] ADD [Updated] [datetime]
ALTER TABLE [dbo].[Products] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[ProductCategories] ADD [Created] [datetime]
ALTER TABLE [dbo].[ProductCategories] ADD [Updated] [datetime]
ALTER TABLE [dbo].[ProductCategories] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[OrderStatusHistoryItems] ADD [Updated] [datetime]
ALTER TABLE [dbo].[OrderStatusHistoryItems] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[Buyers] ADD [Created] [datetime]
ALTER TABLE [dbo].[Buyers] ADD [Updated] [datetime]
ALTER TABLE [dbo].[Buyers] ADD [Deleted] [datetime]
ALTER TABLE [dbo].[Orders] ALTER COLUMN [Created] [datetime] NULL
ALTER TABLE [dbo].[OrderStatusHistoryItems] ALTER COLUMN [Created] [datetime] NULL
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201603020927291_entityTimes', N'OS.DAL.EF.Migrations.Configuration',  0x1F8B0800000000000400ED5D596FE438927E5F60FF43229F6606354E1F5D8D9E823D03978F6E6F97ED9C4AD760F7C99095B453DB4A2947525697B1D85FB60FFB93F62F2CA99347F0D299E9120A28DB22190C063F06836430F87FFFF3BFA77FFBB6F6275F51147B6170363D3A389C4E50E0864B2F78399B6E93E73FFF34FDDB5FFFF55F4EAF96EB6F937F14F94E483E5C3288CFA6AB24D97C98CD627785D64E7CB0F6DC288CC3E7E4C00DD7336719CE8E0F0FFF323B3A9A214C628A694D26A79FB741E2AD51FA07FEF3220C5CB449B68E7F1B2E911FE7DF71CA22A53AB973D628DE382E3A9BDE2F0E2ECF3F1D5C5D4F27E7BEE7600616C87F9E4E9C20081327C1EC7DF812A3451285C1CB62833F38FEC3EB06E17CCF8E1FA39CED0F5576D3161C1E9316CCAA820529771B27E1DA92E0D1492E92195FBC9660A7A5C8B0D0AEB0709357D2EA547067D38F91132CA713BEA60F177E4472A542FDB88DBD00C5F1C125CEE205076999771331E55D09038C16F2EFDDE462EB27DB089D05689B448EFF6E32DF3EF99EFB2B7A7D087F43C159B0F57D9A43CC234E633EE04FF328DCA02879FD8C9E73BE6F30D333B6DC8C2F5816A3CA648DBA099293E3E9E40E57EE3CF9A804002580451246E86714A0C849D072EE24098A024203A522146AE7EA22FF17B561C4E131339DDC3ADF3EA1E025599D4D8FDFE35172ED7D43CBE24BCEC197C0C3430C174AA22D023854D77A135F221F617E8BAA3F86A18F9CC09AD045841C8ACC25FEE3C15B6B8B7DD92CEB14E398868B9DCE2AF02A218D5546E2B8C94DF01C5A029B2A39C25B8D0F2C299C538170FCAB11C247401B011A0B3BFF41126AE09A2530C2DB04DEA43A7DB546A49A9279CB030117BB73BE7A2F69D7C914CD67E4A7E9F1CADB64865D01EB4711DE31563D51B8FE1CFA150928DBE38313BD20A2C6427DDE45B88D5C7BD6B3F12A679FA41B36419655D60C697EA829B6EAA89E0E1A158F465B2C2BB39102C955B05D5B0FF5D1061D4053B143B81BAD550C5F13AD55A8862643BDBEC931DA1AB5873CF9320EFBB736ECDB98ED25C35F6B1DD45401DB20895EAD877F5A6A1CFACABAAE8217DF8B579A01DBD1785DDC2BEA3CE1AACCAA6856E37C150688D1765DED1A3CFC1E5EAC9C28D65476DC41231F56114226957721E16180F48615BFB196BCF67C5B0B891419F5A3B22E2222AD35F3BE0585817BDF29E1EB050E99EF4CB4D2F73B32EC4C22D02222BD0BD82BB42524C9225840B27C8D2C1FDCAAE5D64DF0B495D81E24D045DB1CE3938F4E8CA8A542AA763418BCC5F5D901D05842F7D1124596A249CB8C7A4F59D7F966839B9992FA12A3A8AA1A508047C73F8DE72CB555152769504FA5887D1472565A0ACC20E8283817A4A1540CA75430A43205032F35D93C8FF928E5F8E5D2852D643093ED16785A6A8107C53646F12F1E5613646695CA18CECE0B1ACA25913698D556E473AC9688EF8594ED2203CF68F65DC25A9ED86886123069A589B9D27BAD931B28464B057785E5E22B0DD21F5BD0C7692DD89279F6A27573A53C77E2F8F7305AFEE2C4ABCE17DF0BE46E238C533CECD69BCE6B4B3715EEB6EB2702FFFEEA6AAD6B1E7E0FAF1D17EBA5AB80946A4CEF53E8FE166E93AB604926C32F896B3BA596045A61E7DC75B136B9C66046CB744FB0D92938D153DA05A1D9F8D3D52C5FDDF88EB786275E7E722FB25613039C43982224D96C67AE4FE18B1798B15A6495B39AE5D0B29A676B7192E56B10A75B38879655C514AC62951033136A9E53CE689A41CB6796AB91A550AC3C08BD144C2A5BE1B674273D8F37772839284A1F6474AF234C13CF27BF1D0864DF4D8C0B57B6C5B1A96D7172F4F47CF2D3FB1F9DE5C98F3FA093F76F71EDD7DA82CF76E146BA2FDB7FE9781A4D6BFA87E36FDBAEAAD66848F555FBA32125BBFBA32165137FFEEAA56BC499BE4491199337CA5FE0D976CC719CF53D1C9866F65D793F3AC07C23349F70EDB640D3427BBDA8ECE380238A93964E386C170ACE5035DF7ACB654FE73ABAC5FAFEAD41DFF2466DADF99B18C7ED4FDF84EAEECFDEF0DC0A66250DAAA30D8732470B7E77640A6477C3EB1C799585C729516778112935BD2FF1F7AD9357D784CA3CF25C749E3CAC526D75FF3CC70BF595139713D72572BDB583679879847FCB2FCA625C2E5C87D4615F610A95F1AE48BDC3BCFCA0ABAD1331F0DC46766C66BCCF5568103D976556299FC54F0DA7C5CF36BC21EA39428C3A4F83FCD88DBC4D76C5BB6B6395A8B4CEF4577A35BCA9FE5AACC2283193C9D161273E8DC32C8CBE57BD9DC720003462A1B9F21C9522641204FDC7A6DAAAE80BDC809730F2249BFC39F13CD76BA15D63803D218FE06521CD687FD93075B8CFCA4B66C1422C425E51AE5C16A984F97CD6D321F19053CAF9B1C8223299A54879CB93DB98F58AFEA937FB15A5C75950E3A5104117A5DB983A8F0E8F7F6861EE1CA7853EA7858B95E72F2D95B15046AE93B9AC323522CD6FADEA527877DD0ADD04236BB5E5FAA583A951277F610EADBF91937904E6FE803709529E86CB36740422A37A575BF5A9BC989BAE941CC79D92B655ABF56E7AFB3BE9FBB18BBE2F9EA7433BBE91A30058EFD3FDFD9867AB34BE982AE87A204B232DFF71FB6AED0E9D961975B8DA444F0FF547AD5BCFA055F838A6E0033C1BE9EFC2A86112EDC6CB764D8D1626C6CC4D7CED3B2F554CCC3A513F08A556AFBD7D09F064EFBF629547E38E15FB2D2207F005C4D6CE0B663EF532C30A59144B2600BD50C897F60453501B5638FF36BFFA59261B3EEFFCAECA7A5C438C8C89D7488414A561C577BF4141299343B5F86E880E7889309BA602BF08D79B5CCFC062E70B7C46FF895C3AFF892E7F1CFA5FA9FC3F6818F2C398CAFDDE0404E7711CBA5EDAA7EC7002439FB0955F05CB894508A46A3551C625BBC5FDEE11176AACFA88BCF979F73EC854F9E4DCCD82F25E38B1EB2C454D8EDBB6ACC35CB908179863EE39B37CFE49A81EDB0588EC19780EB90A14630C7B41221A115EE07A1BC737171A47C2D01221F2282BE3532E111E14C48830978E091754F0449199B24EAED374623B9D51F034422DE1BB0E7265E514E88590D12D82A54CEE008A7502EC0FC93A2959A099941B0CD1B2A00B329068233054E0C862A0E8E0A0275D0B778707078295672C14C9BD2D19E3BA4B5C15DFC205DD5E06B6E6F618C51F702DA893E1AC96580FA3582D121306A4BE967D8C5AC96D3D5300F057F7760DA0DC9D410940F39B3ABD009495D800006545B27700CD77324C01C06F7018035435BF68AE7B529514FB2E1D4E29D955505356B97BA1BB365ED90BA992E19A1D27F4325A19710D30581979ECFC5885E3D9C8FA5E13DC863BCCB3199FEA8038E6A017C7695D5C2939EA01574A599BD40F048E1A0E62BCBFB5120752E76B0E60D41D0C4BA449031E6920DCAA4EAD0F4B09FB7DA152D23F26D59727F58340917521952144E24F4A9908F6A883BD50299AB957EBAEC10DE4BB079C817D60526FE9743E24C0A4CE5B1A78E8FDD1041056DEA80613A179859061ACAEB02573CE5012FD41502722134E2A6FD69D4065E98A678A0ED12FAF012C0CAA91A34F43BEC65CC03BC0EB34B8D41BBE95F941E643CFEC7FE641F85B5CA172FEF53A2E79677B6DD3CDB411EFA52FD2CDE3EFB68501C9253B43D3B1F8D9A5795AFC341F11C3DB0CEA26F46FA472FD64A4B0AB8BC7032ECBC110A8EA15B43A1E6A9FAB1B23CE64EB2EC029BB136B432FB4DE56FA2AF9ECFECA8A097EAB06827C7FB7E6AE51AF7BB9807BAB8C3B95AFABB84D0A6D91763420151EB6FDEFDFCAA5D4C3D0934BC2A472388E4A4F238EF11295F534EC324AED3A64BED1E6230E7433D58EB8E16D1288EF1EF005C9DFC8FE287DAB7BC056E6174CFC297089D2D58FBB8F71F9943A5C7C83823EE081933B6BC6F9C5021E3E84D40225F41E4D3C9D540EC9EC2698803EB6F845F5323744844A3622C5FB71C114798F1333C20A6AA624344C197243968C9E844EBE9CD4D0201E3A50F9CCD34753389DA8A1D2F994AF299E5F23114A0B87411A3A828B0B4414F083B1205BC44E5692CDBD173464332500D12AB4AC055F79F861255BD92C6FD295F4A313709F528B5F5D33E5942C49D0B76465B4AA7D2A93760AEB10697B81158BA6025D8F18F5463AC180AA349BD9B9E2D40C20281AF8254AAA84C19BB5FC6465E7BF5D368ED69FC20468E7762DD264DBC79B1BAC84CCA527750B964BD0CC93186AB1D697586C35D85C2BDABD4954FA16982849230F56A6953A1F56AA75F98CA71099CE6BB57351C91E19102565E2D6CAB44DE3D84A352D9F9D1572D238A152B4A019BA75291573B45E4A906FA5B2659C77652329719E901229158D695D4A8591A19712B40855B68C5B90369212B716A56895F653EBA2C9A76EBD64004F3F6563585FBF467261FDF224E0C91BD258409267D1440119F89B013B7C328F33AA55C50A432121B58F994ED875A522449A940845E921A53A22627DA47891D096BA4E3632AF28AD986BC88675C50184A2F0D501CF0E596F1D5A0D98B41FF6CFA1A8147B166D355C1EDF472A0A33AF12A8595ABF12515C34477AB969FD486C2A6841A8559FEBA5097B43285B29F843B4263FC105C200C80D469F10FD4F3E0E957E12E05892794AD41D9B32DF08C6CA2E37BA5A93511173502E1AC86B026C01E7375157109C9B846EC9D27CE62AF761B47317E842A19A6978278A76E62FDE6DA29B51A47AA85466FAE8CFF46D4FF5EB1841CAC3789E20B409D692ECE46B0CF981B2FE48B98E44FA584640A191C496EB4E984DCF98A9268066BEE99170C74B0736DA8D280EF939A7FEA493B6DFF28D52850CC0B3CD46402862EE94676B65DAE96CE1AED0DAC93F9CCE7016176D92ADE3DF864BE4C745C2ADB3D978C14B5C95CCBF4C161BC725DB767F5E4C27DFD67E109F4D5749B2F9309BC529E9F8605D065B73C3F5CC5986B3E3C3C3BFCC8E8E66EB8CC6CC65B0C59F049635E181EFBC202E95CCB64B94BE5A74E924CE53FA14C2C5722D64BB929D244AB6B68B6A99C342B1DB8A0DEF223BF93DD72D8B83CBF34F0757D707E0E2A19221E6E9658D219DB610F1D6BE580E9724D1D09D68CE05B1C22B988BD0DFAE03F9A9B1BC7416CB8D2E9F7D31A74005D162D8A83E9BD32AE368D194CA8FE674CAC05A349DF2A3391DB0658A769DCEB8CE150ED005E8081E072C108D60CA1C4AD7032B7D706D0F5965E96E805B9E643350818FB7955C8CF0A5E037187CF5C750A628569FC618825947A4534C1771590064CB42B668694AE8D9D11AC70A4565D0B1D27080D41F15FD0D8525E2112B7AE8A9288C968D8ACE7EC1BD8539A1D964D0EF2C30427F843EB59D5C17F7996F651DCC4B4A7683F7ABE0C5F7E295085A26C102BB8B7B8E1DF2C1BC7CFA8AAE3808A9CFE6B41E7E0F2F564E148BE4D8140B8AAB0821194D2E6DD418DF95C6C80E606CB4C54D4C7EBF7FFE43A53608913FD6501AA92B764F1A83D42522B6FA6AD1B34EE270DD9A7E19713F04EE8DE7B6397D23DB1EAB747161C028BABA11686FE25B8738DEB328C9BEED8C0AC98FACEAF50AE83B64D01D9272DD740310998A266610B84AD5C5A32EA80038088065679626F8D578061A20594BA1230B7AED783E673B679F2C69E0D5EEB317ADF96EE6D32C6C69278E7F0FA3E52F4EBCE2CC6926C59CE202B9DB88C83B71D61B9624976469F1DF6DC95B0380CD5F24D4A22791289CC36A5D71EDB8187D570179A66629AC2DB85473CA9F42F7B7709B5C054BF2AECC97C4654903C93568033CF369161ADD75511C5F6388A265BA74E534BA986CA13DF128162DCDEAEBCEE83DE0EE423D2528DE40B457830634BA5184D08C6E3F8DA72C67B77E98C9B7FA6C492B7DB10420967FDF4910496F9FD88228BB6FDA0C44121A723D83B3E36F5FBD25AFD1B9240B9D9E97F915BD72AA9C4EE80AAA0301A2F03AAAB94A03FDA64CD66792825DED264471026D27949F2D66380722557D35A774EB2D97D02E07FDBD5F0BB16D2B695C2D51548657F8B2EB62B6FA3EBD3ADE4CDDC324BA9DF48B783A3415598C9D61B76728AFF406FB34558C849A1B360A02DDE8E97915178F9B7F65E1F2E4B4FEBE75D2E6B0A4AAAF365C792E3A4F1E56E91B9CF7CFF36DE4AE3277548649592EF39ACA206B346169E435452F8C7AB7A232905DD56C00D71FB93D0FD94B14BB91B721FB617C97500996830D18593634CA20DD341569E46E399DC52A8C126903C5D4F130F67B1CE2CA9BB21663BD0C1D547BCCCB2974345D9771C7D96D5F593472558FB7AB45C6F1A596F65E8C2FD9EDC00626B11846ABA6696C40A89B3157BC6FCDCC44F9B7D1D0FC0E47491B8BFA860B7ABBC57C5FB7D906EA8FFC2668BD0EC9C2EAD9F784A45C47D37E193D9699F6A53165157C8CEA83825BB770656F118B6E8560483C08A3D2CC26FE82E43E34E0EAA78872270ACA08D2004138DE31C5507D5EA5B1976B0F3F2563B8EAA59706EBBE89EFB6BE7F367D767C7E43CA4802FCED726BE89C4BC2BA1978DF94792D7D6C807E81293784504EA405D848D8DB45D4481BDD1829DC22950AA264B028A6726B16BF92FD2FA057645534EC179E6C0BF89172DA10E079181B3B0EDB0282181D4A810331B3E1BEA75C9AB2804FB5271C965A7BDD2E8B74B5537A43DFFCD6705344CC52C1A5C863E517AEE80236B456AFE3CD84AF66D0ED682691B6B63112D8E84ED2DD1EA981210D81096D93EC9A3101C5A4DAAD8EAF6F4208118DF82CE52A29FF52FE5D4634CAA30931618E527990A045A91CE23CB2111F5E28CB329DCC7377AFB3E9E2354ED0FA80643858FCD3BFF03D449C4B8B0CB74EE03DA33879087F43C1D9F4F8F0E8783A39F73D27CE824BE581933EF02F9A1845523A3A219194D0723DE38BDBC7632254E278E903D198C8E0A18FCDB8A849BF220103053654AFD89CCEF882A70014B3F7043C22D27484FE8C708F9375F6DC49121405D50ED37442D046FC864BC4CD94E4B34DA1AC82E0AB438EE223E069999B6089BE9D4DFF2B2DF561F2E5D72C422BF9EB1D86F897C0FBE7167F7F88B668F2DFD3C9ADF3ED130A5E9215EEECF787D64C51FB1A19674F5E624DA4DCD2C848907D89C4238DADE8A46FE468C8943B1ACDC8700D3223436F652811290D3AB4B7B82CC317B1D0FCC3DAF9F6475BD98F70AA0127A408FBB3EFA82A42075135E934DECDBF3F3285DF4D52F3E2C3E490E8BB7A6CD466A161F5E378A8371EDECC205822A682564C8671CA1F04936F4A398FB87C0BB80422E6EC2D2699B83B355649B93428329AE5521D8892983E396FB68CE1B264D869983AB1E6898A10D48201CF0608AAD9549A886ECD6ADD5E3EDC505D1E1932ADF74A53187784DF51C5DAA958D15F606FF56B15A848396FBFB7EE803474514613937CF202277A1D370F1AA053BA8AE5FD266AAD685922B2D56D8331039C64ECEDA00102F3D8EA742C79810A2B756AFC1D1DFF348E9AB6460D75E8633752CA821D8C0EA523511FE304D4FB1CEECC0CF6EC2AB77236F9D1B6CFF8A03FF521CD86FA69C134E602FDB44091B9C2DE2EBD56442846F4A94F0B08E1D36C74F3A17BEAB306C4EAA9BF355245E9B136FEF392E967ED51DF8FF6036217D5A12668CFDE1A0E0DAC053B13C16C7AAF8208B5A066E82842D6E46A210388C463860C4DE01DA0C45C155807C80FC77CD0E38FE3ACE5B9996945CBB48784B6317AE640309FBD5526545020F3B5BBD9ACEC7444980E18D4EE7E036876EE84F935AEC42C07A93AFA8ED97095C5DC01B2C28175F4A37BB7E6F2A21535B8C98AF6A17E55B17AF6560DCFAB983F96067451B0912F491527A8FEEA441E11281FE0C8F5D68E4FFC49F16F71EA187A8451415C77519DD39AF202B79DC4F262A3EF4D9FEAF86D8D56264C471BD64216F2A7A371528602B21B2779B146E3440C1AA45A301CDA9F3AD63E0BCD016970165AC7441DF583B451C0C529DBB3269E42077B47735588A1BDD55B55AC220B9193C1F2F9FEF2CBC5C3C5F9C3D5CFF79FFFE3717EFEF9EAEEE1F1E6F2F1EEFCF6AA14FF1134926C5166AA2B8E7FB0A55D5F579835FF785424C31B1A26E18AF676FC16918FEA1BE9A3CDBC3F5096C71BDAABB3DC7A6A9734BABD132B6399039185F6565BCCCB104575CEE4C6D13EC80A5919D7C30C8A7393881CD262E045661D92A12A6BED6351141AC18F6E4C2D46EC18B0ED652820436F7AC640083B2C7DB3D392EC154253CD23EB3EEAFE7EB97C4D3D1C018747BE37AF82653A89099760C955F9F2D9FAC9EDD64F3CE2B685ABC7F3AB10A5E13EC8D4CEE4DCCDEED25F38B1EB886FE1A6710C341C08B1CE5866986496AF3F09D5614422B298F41CE25215271116B810C36D1E7981EB6D1C9F930497CF10E8A49125453EE5126D5040664A79934D6AA5EE748A9597757092D7C98209046184AFD483B606C6645D0BF5E9F78135E39E1F146F24FF6098934538ECAC870F0F0E8E844EAEE8A71723688AD9872E51D23358E0A7A5E5F0D08775EC01267C543FE8513EAA17796764BA4385B45E3493E80F48F304A4768238FD9BACADC3CDE405440BEF8721C0063DDEB73760CB5C0C6560CB53DF22D8642F25EE38D84007BFAA6BE75420B6BC3F8B4F56F35C03D0B6040FA8A1DDA0A20E10E7AA187203C002083DBF372A28DD439669A02CF12D2A2049A4FF1DD33F598843F5EDAD5680A65148D9ED4A9A5EFEE5AD40030C840956045CCE1C0E1AA5B3E32374FFD5BAFF3A52379C5FA6C00695D4099ECC3BB70D14A95E9B146B94BE35D30B880AF440112FABFECB52E96ECBBFF4821E0836DDE20590463778B1018AF4D9BE3E81521EC25CAC3C7F297BF04DECBCD25B0AE8C42ACD6A4AE24A676166CDA9B765276B9FACEB0A344CC38D8C66E97374832068AE7A64A01D0475AB90F8F3580563DDAAABE13168A3C78CCEA007052414DFBCDE7CF47D01703F803738E084173C64DD5C44DA638F50F26F75E6CA1E4D28304A60A790303C3531799BA4FFD51BECD3B34B3A67E8355C8F3AA6C62A6E5E5DD21B709F88F27046858FF32E6F0988CED8023B409637B04560F2FAEEAE6D15300FC948F5544B0720FDEE37F677D8610EB3A18F386817F3F442B97C8DCF78A3432709D029C21B3ED9D03C26BC1BC71A7058829EC095FAD2B7A64B3A8252E6F0CFEC7A665FF65C07C99E5696E9A0A1D74BA947F423E9868AE0E37514AE1F53F7B487F091CE28575346CE6306AB28FAD53DD6142F520CA6BA5A1831760E6B674505BF0D6851618F6B6A4DDF5BAC9FCC96D2B620D8BF55903D087ADE60B9621FC82B57F8DC63760226F2C70FE96395E9E4AAF4F2674FB8B2A7F0CEA6CBA7107776764D204D8A018CB094E937BB44FA4C2A540B95C1AC2EDEB316AC92CF24AB1971DEE5860CC86B5556654C5FDD326D934CDB92EFB101F5E429701D24D133A8209B7804EAD967883449D193CD974802DDFC3B44384DD253169C47843A841C506DE7F1E60E25D962425725E0742B540AE451579B3B26DBD49DFB602AEBCEF3A8EBCEFD5475751726AE50619100D53247E1C617AD5B55BBB2F58FB259591675AB32CF372364523B843044A90C52AC96790C2429AD4D598D2DFDEAF051564F9543511F75966E244D60630C962A90512A5D21AFF958D1E0498725331CE50B3071B2CEBE83933549B2EE4C2D76848CFAAE7DB545566149CA78289FF696575D64E12A645F1F36B8C038A14AB073AEFE2E1A77A6C5D809E923D4E537C16854DF2C124930C9FC529F6DB4B940A437EEE44231BBA4073550D632A849830B48763D0C108CD14DB2761B042CFEA9F2D987C622905C7D02246072498A61596274A5DC0B698AA64B2DA9941290DABA500AD3472F14E8324FE742614C3C4128796AEB4229EC39BD50E0AD4160A7946A41F149218206A26CA1F9F984AF6F3D70B7A27344D0C68C00882CB1B14060D77E40200677003A1108B39C4C4BE75FDA693AEFBA2E6BB9D2C5BD0EC3621961655215A6921A379B75B606DAABF0C6664F26E83DAB94D7FC8BA2A1500B5B6F9AD43D58DE58338F62A829FCC28B6E5295A61709EB416C4EAB0531F13EB0066252BACDF621260590842CDD092CF7D1B41118E4D6597788EC9A80049F42857651BA1F722638B3119ADBDDF9B7C1748DC4754E3F7F480E4F5A40409FB388C2D54B6A3CE81DC3DA9948A59B521511204B4B22911BD472D7A516CCE8EECC24C00507689CCE51073472A5062E64DC0E6A2633AE2240F3E5AE242DF42DB3DF98195AD997B6F4B6AD6F835CAD37F292B0DF2A519D898BCA53B20D597FBAD38A0374086873B66FB1B1458CB9F228BB4C3B9D657BBBF907FC27D69ACE0BBA0D97C88FD3AFA7B3CF7842F6D65974BAD34B147B2F1589534C33402E73745EE62147CBC5293EC75191A548CEC57F8B1267E924CE799478CF0E6E6A1492470CBDE0653A499F66230F253DA1E54D70BF4D36DB043719AD9F7CC65A209E00AAFA4F6702CFA7F769D8EFB88D2660363D129FF33EF8B8C50B8E92EF6B20F69F84047131C883B192BE4C4850D697D792D25D181812CAC5577A463CA0F5C6C7C4E2FB60E17C457578C39AF7137A715C62DEE58FBCC988E83B8215FBE9A5E7BC44CE3ACE6954E5F19F18C3CBF5B7BFFE3FAA57BB27C3740100 , N'6.1.3-40302')


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
    SET @newDbVersion = '0.34'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, 'Create [IX_Locations_UserIdName]'
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info