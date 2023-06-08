using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace PostNLPAPI
{
    class Program
    {
        private static string segTagPostUrl = "https://eae266ec46b040f9afb1ae22bef2676e.apig.cn-north-4.huaweicloudapis.com/v1/infers/240dd325-dfaf-4950-81a1-992f3aae0164";
        private static string X_Apig_AppCode = "2fbd1dee3ec64bf3a35c860027f00d84faa45118659841f3a28153759f78e2cc";
        private static string token = "0000";//注册后，获利的token


        //single 一次处理一个文本
        static void Main(string[] args)
        {
            //单个文本输入进行分词
            singleSeg();

            //多个文本输入进行分词
            //multiSeg();

            //单个文本输入进行情感计算
            //singleMod();

            //多个文本输入进行情感计算
            //multiMod();

            //多个文本输入进行关键词提取
            //multiKeywordsEx();

            //单个文本输入进行关键词提取
            //singleKeywordsEx();

            //多组文本对输入进行文本比对
            //multiContrast();

            //单组文本对输入进行文本比对
            //singleContrast();

            //多个文本输入进行标题党识别，要求第一句为标题
            //multiTitleDang();

            //单个文本输入进行标题党识别，要求第一句为标题
            //singleTitleDang();
        }

        static void multiSeg()
        {
            //多个文本分词
            string _segTagPostUrl = segTagPostUrl + "/api/MultiSegTag";
            string sour = "中国传媒大学融媒体语言智能服务开放平台，是一个面向研究者的免费自然语言处理工具包，由汉语分词、自动关键词语、自动摘要、情感计算、信息抽取和标题党识别等技术集成，更多功能持续更新中，欢迎您关注并使用。";
            segMultiPostJson segMultiJson = new segMultiPostJson();
            segMultiJson.sourList = new List<string>();
            for (int i = 1; i < 6; i++)
            {
                segMultiJson.sourList.Add(i.ToString()+":"+sour.Replace("\"", ""));
            }
           
            segMultiJson.isTag = "1";
            segMultiJson.token = token;
            string rejson = multiPost(_segTagPostUrl, segMultiJson);
            Console.WriteLine(rejson);
        }



        static void singleSeg()
        {
            //单个文本分词
            string _segTagPostUrl = segTagPostUrl + "/api/SegTag";
            string sour = "中国传媒大学融媒体语言智能服务开放平台，是一个面向研究者的免费自然语言处理工具包，由汉语分词、自动关键词语、自动摘要、情感计算、信息抽取和标题党识别等技术集成，更多功能持续更新中，欢迎您关注并使用。";
            segSinglePostJson segJson = new segSinglePostJson();
            segJson.sour = sour.Replace("\"", "");
            segJson.isTag = "1";
            segJson.token = token;
            string rejson = singlePost(_segTagPostUrl, segJson);
            Console.WriteLine(rejson);
        }


        static void multiMod()
        {
            //多个文本情感计算
            string _segTagPostUrl = segTagPostUrl + "/api/MultiMod";
            segMultiPostJson segMultiJson = new segMultiPostJson();
            segMultiJson.sourList = new List<string>();
            segMultiJson.sourList.Add("我今天很开心");
            segMultiJson.sourList.Add("今天我的小狗丢了，我几天吃不下饭");
            segMultiJson.sourList.Add("该死的疫情，何时才能清0");
            segMultiJson.sourList.Add("恋爱中远离极端男女，不然在一起也是很恐怖的，比如分手一方就要死要活的。远离，千万别心软。");
            for (int i = 1; i < segMultiJson.sourList.Count; i++)
            {

                segMultiJson.sourList[i].Replace("\"", "");
            }
            segMultiJson.textType = "string";
            segMultiJson.token = token;
            string rejson = multiPost(_segTagPostUrl, segMultiJson);
            Console.WriteLine(rejson);
        }



        static void singleMod()
        {
            //单个文本情感计算
            string _segTagPostUrl = segTagPostUrl + "/api/Mod";
            string sour = "今天天气很好,很高兴在这里遇到你";
            segSinglePostJson segJson = new segSinglePostJson();
            segJson.sour = sour.Replace("\"", "");
            segJson.textType = "string";
            segJson.token = token;
            string rejson = singlePost(_segTagPostUrl, segJson);
            Console.WriteLine(rejson);
        }


        static void multiKeywordsEx()
        {
            //多个文本关键词提取
            string _segTagPostUrl = segTagPostUrl + "/api/MultiKeywordsEx";
            segMultiPostJson segMultiJson = new segMultiPostJson();
            segMultiJson.sourList = new List<string>();
            
           //添加测试语句  
            segMultiJson.sourList.Add("聚团结力量，迈向奋斗征程。10日，全国政协十三届五次会议圆满完成各项议程胜利闭幕。来自34个界别的近2000名全国政协委员聚焦经济社会发展深入协商议政，把握大局大势广泛凝聚共识，汇聚起团结奋斗、共创未来的磅礴力量。会议期间，习近平总书记亲切看望参加会议的农业界、社会福利和社会保障界委员，并参加联组会，听取意见和建议，发表重要讲话。从深刻揭示我国发展五个方面的战略性有利条件，到确保粮食安全、推进乡村振兴，再到关爱困难群众、推动社会保障事业高质量发展，总书记的重要讲话，把握大局大势，回应社会关切，作出科学谋划，彰显了以人民为中心的发展思想，为广大政协委员履职尽责提供思想引领，极大增强了奋进新征程、再创新辉煌的信心和底气。");
            segMultiJson.sourList.Add("守望圆心就能万众一心。旗帜鲜明讲政治，坚持中国共产党的领导特别是党中央集中统一领导，是做好人民政协工作的根本保证。历史和实践充分证明，对人民政协来说，党的领导越有力，党的旗帜越鲜明，就越能巩固和壮大爱国统一战线，越能有效汇聚中国人民和海内外中华儿女的智慧力量。面向未来，人民政协只有坚定不移坚持党的全面领导，把“两个确立”的政治共识转化为“两个维护”的自觉行动，才能更好地成为坚持和加强党对各项工作领导的重要阵地、用党的创新理论团结教育引导各族各界代表人士的重要平台、在共同思想政治基础上化解矛盾和凝聚共识的重要渠道。人民政协因团结而生、依团结而存、靠团结而兴，肩负着加强中华儿女大团结的历史责任。当前，世界百年未有之大变局加速演进，改革发展稳定任务之重、矛盾风险挑战之多、治国理政考验之大前所未有，更加需要加强中华儿女大团结。坚持一致性和多样性统一，有效运用制度优势寻求最大公约数、画出最大同心圆，在勤勉履职中增进团结、合作共事中巩固团结、共同奋斗中深化团结，就能把更多力量汇聚到共襄复兴伟业的历史进程之中，推动形成全体中华儿女心往一处想、劲往一处使的生动局面。");
            segMultiJson.sourList.Add("做好人民政协工作，关键在于紧扣党和国家工作大局，以高质量建言服务高质量发展，将制度优势更好转化为国家治理效能。既坚持问题导向，回应群众关切，加强调查研究，建睿智之言、献务实之策、谋长远之举，又持续开展民主监督，聚焦问题提出改进意见，助推工作落实；既加强学习，不断提升履职能力和水平，又创新协商方式载体，拓展协商深度，不断提高履职质量。春光无限好，奋进正当时。更加紧密地团结在以习近平同志为核心的党中央周围，增强“四个意识”、坚定“四个自信”、做到“两个维护”，踔厉奋发、团结奋斗，新时代人民政协事业发展必将开创新局面，为夺取全面建设社会主义现代化国家新胜利、实现中华民族伟大复兴的中国梦作出新的更大贡献，以实际行动迎接党的二十大胜利召开。");
            segMultiJson.sourList.Add("春和景明，万物勃发。肩负着亿万人民重托，近3000名全国人大代表齐聚北京共商国是。即将召开的十三届全国人大五次会议，是我国政治生活中的一件大事。开好这次大会，对于统一思想、坚定信心，动员全国各族人民把智慧和力量凝聚到党中央决策部署上来，以实际行动迎接党的二十大胜利召开，具有十分重要的意义。过去一年，在以习近平同志为核心的党中央坚强领导下，全国各族人民团结奋斗，攻坚克难，办成了一系列大事要事，战胜了一系列风险挑战，推动党和国家事业取得新的重大成就，在中华民族伟大复兴历史进程中写下了浓墨重彩的一笔。一年来，十三届全国人大及其常委会深入学习贯彻习近平新时代中国特色社会主义思想特别是习近平总书记关于坚持和完善人民代表大会制度的重要思想，努力践行全过程人民民主理念，持续加强宪法实施和监督，在确保质量前提下加快立法工作步伐，共审议法律草案、决定决议草案71件，通过其中54件，进一步增强监督工作实效，更好发挥人大代表作用，不断加强人大自身建设，推动新时代人大工作再上新台阶，为经济社会发展提供重要制度保障、作出重要贡献。");
            for (int i = 1; i < segMultiJson.sourList.Count; i++)
            {

                segMultiJson.sourList[i].Replace("\"", "");
            }
            segMultiJson.keywordsNumber = "6";
            segMultiJson.token = token;
            string rejson = multiPost(_segTagPostUrl, segMultiJson);
            Console.WriteLine(rejson);
        }



        static void singleKeywordsEx()
        {
            //单个文本关键词提取
            string _segTagPostUrl = segTagPostUrl + "/api/KeywordsEx";
            string sour = "当前，国际形势继续发生深刻复杂变化，百年变局和世纪疫情相互交织，经济全球化遭遇逆流，大国博弈日趋激烈，世界进入新的动荡变革期，国内改革发展稳定任务艰巨繁重。回望过往的奋斗路，眺望前方的奋进路，我们更加深刻地认识到，中国共产党充分发挥总揽全局、协调各方的领导核心作用，为沉着应对各种重大风险挑战提供根本政治保证；我国政治制度和治理体系在应对新冠肺炎疫情、打赢脱贫攻坚战等实践中进一步彰显显著优越性，“中国之治”与“西方之乱”对比更加鲜明；在持续快速发展积累的坚实基础上，我国经济实力、科技实力、国防实力、综合国力显著增强，经济体量大、回旋余地广，又有超大规模市场，长期向好的基本面不会改变，具有强大的韧性和活力；我国社会大局稳定，人民获得感、幸福感、安全感显著增强，社会治理水平不断提升，续写了社会长期稳定的奇迹；中国人民积极性、主动性、创造性进一步激发，志气、骨气、底气空前增强，党心军心民心昂扬振奋。新的伟大征程上，充分用好我国发展仍具有的诸多战略性的有利条件，我们有坚强决心、坚定意志、坚实国力应对挑战，有足够的底气、能力、智慧战胜各种风险考验。";
            segSinglePostJson segJson = new segSinglePostJson();
            segJson.sour = sour.Replace("\"", "");;
            segJson.keywordsNumber = "6";
            segJson.token = token;
            string rejson = singlePost(_segTagPostUrl, segJson);
            Console.WriteLine(rejson);
        }


        static void multiContrast()
        {
            //同时输入多组文本对进行比对
            string _segTagPostUrl = segTagPostUrl + "/api/MultiBidui";
            segMultiPostJson segMultiJson = new segMultiPostJson();

            
            

            //添加测试语句  
            segMultiJson.sourParaList = new string[,] { { "互联网产业为人们带来便利，塑造了人们新的娱乐方式。", "互联网产业为人们带来便利的生活，塑造了人们新的快活方式。" }, { "《规定》强调算法推荐服务提供者应当坚持主流价值导向，优化算法推荐服务机制，积极传播正能量，促进算法应用向上向善。",
            "《规定》强调算法推荐服务提供者应当坚持主流价值导向，优化算法推荐服务机制，积极传播正能量，促进算法应用向上向善。" }, };
            for (int i = 0; i < segMultiJson.sourParaList.Length/2; i++)
            {
             
                for (int j = 0; j < 2; j++)
                segMultiJson.sourParaList[i,j].Replace("\"", "");
            }
            segMultiJson.token = token;
            string rejson = multiPost(_segTagPostUrl, segMultiJson);
            Console.WriteLine(rejson);
        }



        static void singleContrast()
        {
            //单组文本对进行比对
            string _segTagPostUrl = segTagPostUrl + "/api/Bidui";
        
            segSinglePostJson segJson = new segSinglePostJson();
            
            
            string sour1 = "中国传媒大学是教育部直属的首批“双一流”建设高校，“211工程”重点建设大学，“985优势学科创新平台”重点建设高校。";
            string sour2 = "中传是教育部直属的首批“双一流”建设高校，“211工程”重点建设大学，“985优势学科创新平台”重点建设高校。";
            segJson.sour1 = sour1.Replace("\"", "");
            segJson.sour2 = sour2.Replace("\"", "");
            segJson.token = token; 
            string rejson = singlePost(_segTagPostUrl, segJson);
            Console.WriteLine(rejson);
        }



        static void multiTitleDang()
        {
            //多个文本标题党识别
            string _segTagPostUrl = segTagPostUrl + "/api/MultiTitleDang";
            segMultiPostJson segMultiJson = new segMultiPostJson();
            segMultiJson.sourList = new List<string>();
            
            segMultiJson.sourList.Add("意想不到!这个地方比云南美多了。相较往年，今年的春季工作会召开时间提前了将近一个月，实现早部署、早落实、早见效，激励教职员工以更快的速度、更好的状态投入到工作中。会议形式也进行了创新，由原来只是书记、校长作报告，拓展为除书记、校长全面部署学校工作外，各分管校领导也对各自分管工作进行布置安排，实现热传导效应，推动党建工作与学校工作的一体贯通。同时将参会人员扩大到全体教职工，有助于大家更好地了解学校发展和工作部署，统一理想、统一思想、统一步调。这些创新做法，受到了干部教师的一致欢迎和好评。");
            segMultiJson.sourList.Add("以社会主流价值为导向，强调舆情管理与引导。算法推荐服务提供者应当坚持主流价值导向，优化算法推荐服务机制，积极传播正能量，促进算法应用向上向善。《规定》着眼互联网信息服务中潜在的算法影响网络舆论、算法诱导用户沉迷或过度消费、算法共谋和不正当竞争等算法应用风险，由此引出治理对象，通过算法规制规范互联网信息服务算法推荐活动，维护国家安全和社会公共利益。《规定》指出，具有舆论属性或者社会动员能力的算法推荐服务提供者，应当在提供服务之日起十个工作日内，通过互联网信息服务算法备案系统填报服务提供者的名称、服务形式、应用领域、算法类型、算法自评估报告、拟公示内容等信息，履行备案手续。");
            for (int i = 1; i < segMultiJson.sourList.Count; i++)
            {
                
                segMultiJson.sourList[i].Replace("\"", "");
            }
            segMultiJson.token = token;
            string rejson = multiPost(_segTagPostUrl, segMultiJson);
            Console.WriteLine(rejson);
        }



        static void singleTitleDang()
        {
            //单个文本标题党识别
            string _segTagPostUrl = segTagPostUrl + "/api/TitleDang";
            string sour = "意想不到!这个地方比云南美多了。相较往年，今年的春季工作会召开时间提前了将近一个月，实现早部署、早落实、早见效，激励教职员工以更快的速度、更好的状态投入到工作中。会议形式也进行了创新，由原来只是书记、校长作报告，拓展为除书记、校长全面部署学校工作外，各分管校领导也对各自分管工作进行布置安排，实现热传导效应，推动党建工作与学校工作的一体贯通。同时将参会人员扩大到全体教职工，有助于大家更好地了解学校发展和工作部署，统一理想、统一思想、统一步调。这些创新做法，受到了干部教师的一致欢迎和好评。";
            segSinglePostJson segJson = new segSinglePostJson();
            segJson.token = token;
            segJson.sour = sour.Replace("\"", "");
            string rejson = singlePost(_segTagPostUrl, segJson);
            Console.WriteLine(rejson);
        }


        //单个文档调用
        private static string singlePost(string postUrl, segSinglePostJson json)
        {
          
            string result = "";
            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
            //Post请求方式  
            request.Method = "POST";

            request.Timeout = 80000;
            //内容类型
            request.ContentType = "application/json";

            request.Headers.Add("X-Apig-AppCode", X_Apig_AppCode);
           

            string _json = JsonConvert.SerializeObject(json);
            byte[] payload = Encoding.UTF8.GetBytes(_json);

            request.ContentLength = payload.Length;

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(payload, 0, payload.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }


        //多个文档调用
        private static string multiPost(string postUrl, segMultiPostJson json)
        {

            string result = "";
            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
            //Post请求方式  
            request.Method = "POST";

            request.Timeout = 80000;
            //内容类型
            request.ContentType = "application/json";

            request.Headers.Add("X-Apig-AppCode", X_Apig_AppCode);
            

            string _json = JsonConvert.SerializeObject(json);
            byte[] payload = Encoding.UTF8.GetBytes(_json);

            request.ContentLength = payload.Length;

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(payload, 0, payload.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

    }

    
    class segSinglePostJson
    {
        public string sour { get; set; }
        public string sour1 { get; set; }
        public string sour2 { get; set; }
        public string isTag { get; set; }
        public string textType { get; set; }
        public string keywordsNumber { get; set; }
        public string token { get; set; }
    }

    class segMultiPostJson
    {
        public List<string> sourList { get; set; }
        public string[,] sourParaList { get; set; }
        public string isTag { get; set; }
        public string textType { get; set; }
        public string keywordsNumber { get; set; }
        public string token { get; set; }
    }
   
}
