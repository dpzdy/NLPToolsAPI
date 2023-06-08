const express = require('express');
const { createProxyMiddleware } = require('http-proxy-middleware');
const app = express();
//这一句是标明项目的入口，即index.html的位置，我这里位置就是./static/index.html
app.use(express.static('./'))
//  /yuqing-Toolkits是匹配规则  target是代理服务器位置
app.use('/api', createProxyMiddleware({ 
    target: 'https://eae266ec46b040f9afb1ae22bef2676e.apig.cn-north-4.huaweicloudapis.com/v1/infers/240dd325-dfaf-4950-81a1-992f3aae0164/', changeOrigin: true 

}));
 
app.listen(3001,_=>{
    //服务启动成功的回调，也可以不定义
    console.log('服务启动成功！');
    console.log('代理启动成功！');
});//端口自定义

