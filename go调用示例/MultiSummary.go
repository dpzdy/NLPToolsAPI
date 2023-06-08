package main
//MultiSummary接口测试
import (
	"fmt"
	"io/ioutil"
	"net/http"
	"bytes"
	"encoding/json"
)

func main() {
	httpPostJson()
}
func httpPostJson() {
	type dataGroup struct { 
        SentenceNumber    string `json:"sentenceNumber"`
        Token   string  `json:"token"`
        SurList [ ] string `json:"sourList"`
    } 
	data := dataGroup { 
        SentenceNumber :  "3" , 
        Token :  "test" , 
		SurList : [ ] string { "中国传媒大学是教育部直属的首批“双一流”建设高校，“211工程”重点建设大学，“985优势学科创新平台”重点建设高校。学校始建于1954年，2004年8月由北京广播学院更名为中国传媒大学。学校坐落于北京古运河畔，地处首都功能核心区和北京城市副中心之间，交通便利，区位优势明显。校园环境优美，占地面积46.37万平方米，总建筑面积63.88万平方米。办学67年来，学校秉承“立德、敬业、博学、竞先”的校训，以培养“弘道崇德、经世致用”的传媒人为己任，培养了大量党和国家所需、能够应对未来媒体挑战、驰骋于国际舞台的优秀传媒人才,为党和国家的传媒事业以及经济社会发展作出了重要贡献，被誉为“中国广播电视及传媒人才摇篮”“信息传播领域知名学府","中国传媒大学是教育部直属的首批“双一流”建设高校，“211工程”重点建设大学，“985优势学科创新平台”重点建设高校。学校始建于1954年，2004年8月由北京广播学院更名为中国传媒大学。学校坐落于北京古运河畔，地处首都功能核心区和北京城市副中心之间，交通便利，区位优势明显。校园环境优美，占地面积46.37万平方米，总建筑面积63.88万平方米。办学67年来，学校秉承“立德、敬业、博学、竞先”的校训，以培养“弘道崇德、经世致用”的传媒人为己任，培养了大量党和国家所需、能够应对未来媒体挑战、驰骋于国际舞台的优秀传媒人才,为党和国家的传媒事业以及经济社会发展作出了重要贡献，被誉为“中国广播电视及传媒人才摇篮”“信息传播领域知名学府" } , 
    } 
	
	requestBody := new(bytes.Buffer)
	json.NewEncoder(requestBody).Encode(data)
	fmt.Println(requestBody)
    url:= "https://eae266ec46b040f9afb1ae22bef2676e.apig.cn-north-4.huaweicloudapis.com/v1/infers/240dd325-dfaf-4950-81a1-992f3aae0164/api/MultiSummary"
    req, err := http.NewRequest("POST", url, requestBody)
    req.Header.Set("Content-Type", "application/json")
	req.Header.Set("X-Apig-AppCode","2fbd1dee3ec64bf3a35c860027f00d84faa45118659841f3a28153759f78e2cc")
    client := &http.Client{}
    resp, err := client.Do(req)
    if err != nil {
        // handle error
    }
    defer resp.Body.Close()
 
    statuscode := resp.StatusCode
    body, _ := ioutil.ReadAll(resp.Body)
    fmt.Println(string(body))
    fmt.Println(statuscode)

}