package main
//Mod接口测试
import (
	"fmt"
	"io/ioutil"
	"net/http"
	"bytes"
)

func main() {
	httpPostJson("时光清浅新的一天总会如约而至白云轻轻的飘时光清浅新的一天总会如约而至白云轻轻的飘时光清浅新的一天总会如约而至白云轻轻的飘时光清浅新的一天总会如约而至白云轻轻的飘时光清浅新的一天总我去到底")
}
func httpPostJson(sour string) {
    jsonStr :=[]byte(fmt.Sprintf(`{ "textType": "string", "token": "test","sour":"%s"}`,sour))
    url:= "https://eae266ec46b040f9afb1ae22bef2676e.apig.cn-north-4.huaweicloudapis.com/v1/infers/240dd325-dfaf-4950-81a1-992f3aae0164/api/Mod"
    req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonStr))
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