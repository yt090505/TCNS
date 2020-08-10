// 构建TCP服务 服务端
const net = require('net')

const server = net.createServer()

server.on('connection', clientSocket => {
  console.log('有新的客户端连接了')
  //服务端通过 clientSocket 监听 data 事件
  clientSocket.on('data', data => {
    // console.log(data)
    // 把数据转换成字符串格式
    console.log('来自客户端消息:', data.toString())
  })
  // 通过clientSocket 给当前连接的客户端发送数据
  clientSocket.write('hello，我是服务端')
  // 服务端监听 data 事件，获取终端中输入的数据
  process.stdin.on('data', data => {
    // 把终端中输入的数据发送给客户端
    clientSocket.write(data.toString().trim())
  })
})

// 监听端口
server.listen(9878, () => console.log('Server runing at http://127.0.0.1:9878'))