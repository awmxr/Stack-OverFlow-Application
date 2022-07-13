from math import trunc
from pydoc import cli
import socket
from time import sleep	
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
                ,"/GetTags" : Get.Get_Tags , "/PostQuestion" : Post.Post_Question , "/GetUpdate" : Get.Get_Update , "/GetSpecialTagsQuestion" : Get.GetSpecialTagsQuestion
                ,"/GetMyNQuestions" : Get.Send_NMyQuestions , "/DeleteQuestion" :Get.delete_Question , "/GetVote" : Get.Get_Vote,
                "/Postanswer" : Post.Post_Answer , "/DeleteAnswer" : Get.delete_Answer , "/Changeintrested" : Get.Change_intrested,
                "/GetNTagsForm" : Get.GetNTagsForm , "/GetNUsers" :Get.GetNUsers ,  "/Getusernames" :Get.Get_Usernames}


commands_post = {}

# a forever loop until we interrupt it or
# an error occurs


# ///////////////////////////////////////////////////////////////////////////////////////

q = queue.Queue()
# y = threading.Thread(target=Function.check_client_connection )

# y.start()


def first() :
    while True:
        # Establish connection with client.
        print("waiting")
        c, addr = s.accept()
        if(addr in clientConected.keys()):
            print("cooooooooooooooooooooooooontinueeeeeeeeeee")
            continue

        clientConected[addr[0]] = (c , dt.datetime.now())
        # Function.q3.get(clientConected)
        print(clientConected , "ccccccccccccccccccccc")

        # xlist[0][addr] = (c,dt.datetime.now())
        # Function.q2.put([c,dt.datetime.now() , addr])
        print("xdict = " , xlist[0])
        print ('Got connection from', addr )
        # raise NameError

        a = ""
        b = ""
        
        # while (Function.check_Fin(b) == False):
        
        #     print("xxxxxxxxxxxxxxxxxxxx")
        #     b = c.recv(100).decode()
        #     print("b : " , b)
        #     a += b

        # print(a ,"---end--")
        # a = a.replace(f"<SSFINSS>" , "")
        # print(a , "------")
        
        # ar  = a.split(Setting.Split_char)
        # if len(ar) >= 3:
        #     method = ar[0]
        #     path = ar[1]
        #     params = ar[2]
        #     print('params = ' , params)

        #     print("METHOD: ", method)
        #     print("PATH: ", path)
            
        #     # if (path == "/GetUserInfo"):
        #     #     c.send('{"UserName":"Amir", "Age":20}'.encode())
        #     # else:
        #     #     c.send("command not found.".encode()) 
            
        #     answer = commands_get[path]
        #     x = threading.Thread(target=answer, args=(params,q))
        #     x.start()
        #     x.join()
            
            
        #     result = q.get()
        #     print("result :       ",result)
        #     c.send((result +"<SSFINSS>").encode()  )
            
            
            # c.send(answer(params).encode())

        # send a thank you message to the client. encoding to send byte type.
        # c.send('Thank you for connecting'.encode())

        # Close the connection with the client
        # c.close()

    # Breaking once connection closed
    # break

def Second() :
    while True:

        try:
            # Establish connection with client.

            # Function.q2.put([c,dt.datetime.now() , addr])
            # print("xdict = " , xlist[0])
            # print ('Got connection from', addr )
            
            a = ""
            b = ""
            c = None
            addr = ""
            while(c == None):
                for i in list(clientConected):
                    print(clientConected[i])
                    a = clientConected[i][0].recv(1024).decode()
                    if("Get".lower() in a.lower() or "Post".lower() in a.lower()) == False:
                        # raise ZeroDivisionError
                        continue
                    else:
                        addr0 = i
                        clientConected[i] = (clientConected[i][0] , dt.datetime.now())
                        print("new message")
                        print(a)
                        c = clientConected[i][0]
                        break
            
            # print(a2 , "ttttttt")

            
            if(not Function.check_Fin(a)):

                while (Function.check_Fin(a) == False):
                    print(c.fileno() , "state conections")    
                    print("xxxxxxxxxxxxxxxxxxxx")
                    b = c.recv(100).decode()
                    
                    print("b : " , b)
                    print(b , "tttttttttttttttttttt3")
                    a += b
            print(a , "ttttttt2")
            
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
                # clientConected[addr0][2].append([path , params])
                
                # if (path == "/GetUserInfo"):
                #     c.send('{"UserName":"Amir", "Age":20}'.encode())
                # else:
                #     c.send("command not found.".encode()) 
                
                # if(path == "/FinsihP"):
                #     del clientConected[addr0]
                
                answer = commands_get[path]
                
                x = threading.Thread(target=answer, args=(params,q))
                x.start()
                # x.join()
                
                
                result = q.get()
                print("result :       ",result)
                print(c)

                c.send((result +"<SSFINSS>").encode())
                

        except:
            pass
            
            # c.send(answer(params).encode())

        # send a thank you message to the client. encoding to send byte type.
        # c.send('Thank you for connecting'.encode())

        # Close the connection with the client
        # c.close()

    # Breaking once connection closed
    # break

def check():

    while True:
        try:
            if len(clientConected) > 0 :
                for i in list(clientConected):
                    pass
                    # print(clientConected[i][0])
                    # print(clientConected[i][0].fileno())
        except :
            pass

def Check_clients():
    while True:
        sleep(2)
        Function.check_client_connection(clientConected)






print("test")
xy1 = threading.Thread(target=first)
xy2 = threading.Thread(target=Second)
xy3 = threading.Thread(target=check)
xy4 = threading.Thread(target=Check_clients)

xy1.start()
xy2.start()
# xy3.start()
xy4.start()

# Check_clients()