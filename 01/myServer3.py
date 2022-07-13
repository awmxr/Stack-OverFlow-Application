import socket	
import Get
import Post
import Setting
import threading , queue
import Function


import datetime as dt




s = socket.socket()		
print ("Socket successfully created")


port = Setting.port			


s.bind(('', port))		
print ("socket binded to %s" %(port))


s.listen(5)	
print ("socket is listening")

# //////////////////////////////////////////

clientConected = {}
xlist = []
xlist.append(clientConected)

commands_get = {"/GetUserInfo":Get.GetUserInfo,"/LoginUser" :Get.LoginUser , "/SignUp" : Post.SignUp  , "/GetNQuestion" : Get.Send_NQuestions , "/GetNQuestionAnswer" : Get.Get_Question_Answer
                ,"/GetTags" : Get.Get_Tags , "/PostQuestion" : Post.Post_Question}
commands_post = {}

# a forever loop until we interrupt it or
# an error occurs


# ///////////////////////////////////////////////////////////////////////////////////////

q = queue.Queue()
# y = threading.Thread(target=Function.check_client_connection )

# y.start()
 
while True:

    

    

    # Establish connection with client.
    print("waiting")
    c, addr = s.accept()
    
    # xlist[0][addr] = (c,dt.datetime.now())
    Function.q2.put([c,dt.datetime.now() , addr])
    print("xdict = " , xlist[0])
    print ('Got connection from', addr )
    a = ""
    b = ""
    
    while (Function.check_Fin(b) == False):
    
        print("xxxxxxxxxxxxxxxxxxxx")
        b = c.recv(100).decode()
        print("b : " , b)
        a += b

    print(a ,"---end--")
    a = a.replace(f"<SSFINSS>" , "")
    print(a , "------")
    
    ar  = a.split(Setting.Split_char)
    if len(ar) >= 3:
        method = ar[0]
        path = ar[1]
        params = ar[2]
        print('params = ' , params)

        print("METHOD: ", method)
        print("PATH: ", path)
        
        # if (path == "/GetUserInfo"):
        #     c.send('{"UserName":"Amir", "Age":20}'.encode())
        # else:
        #     c.send("command not found.".encode()) 
        
        answer = commands_get[path]
        x = threading.Thread(target=answer, args=(params,q))
        x.start()
        # x.join()
        
        
        result = q.get()
        print("result :       ",result)
        c.send((result +"<SSFINSS>").encode()  )
        
        # c.send(answer(params).encode())

    # send a thank you message to the client. encoding to send byte type.
    # c.send('Thank you for connecting'.encode())

    # Close the connection with the client
    c.close()

    # Breaking once connection closed
    # break
