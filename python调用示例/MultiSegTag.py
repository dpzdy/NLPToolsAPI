#MultiSegTag接口调用示例
import requests
import json
#请求地址
url = 'https://eae266ec46b040f9afb1ae22bef2676e.apig.cn-north-4.huaweicloudapis.com/v1/infers/240dd325-dfaf-4950-81a1-992f3aae0164/api/MultiSegTag'
#sourList为待分词语料
sourList = ["测试中文分词","测试中文分词"]
data = {"token":"test","isTag":"1","sourList":sourList}
data = json.dumps(data)
data = data.encode('UTF-8')
headers = {'Content-Type':'application/json','X-Apig-AppCode':'2fbd1dee3ec64bf3a35c860027f00d84faa45118659841f3a28153759f78e2cc'}
r = requests.post(url, data=data, headers=headers)
print(r.json())
