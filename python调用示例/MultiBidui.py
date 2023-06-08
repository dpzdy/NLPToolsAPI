#Bidui接口调用示例
import requests
import json
#请求地址
url = 'https://eae266ec46b040f9afb1ae22bef2676e.apig.cn-north-4.huaweicloudapis.com/v1/infers/240dd325-dfaf-4950-81a1-992f3aae0164/api/MultiBidui'
#sour1,sour2为测试语料
sourParaList = [
    ["中国传媒大学是教育部直属的首批“双一流”建设高校，“211工程”重点建设大学，“985优势学科创新平台”重点建设高校。",
     "中传是教育部直属的首批“双一流”建设高校，“211工程”重点建设大学，“985优势学科创新平台”重点建设高校。"],
    ["测试语料A",
     "测试语料B"],
]
data = {"token":"test","sourParaList":sourParaList}
data = json.dumps(data)
data = data.encode('UTF-8')
headers = {'Content-Type':'application/json','X-Apig-AppCode':'2fbd1dee3ec64bf3a35c860027f00d84faa45118659841f3a28153759f78e2cc'}
r = requests.post(url, data=data, headers=headers)
print(r.json())
