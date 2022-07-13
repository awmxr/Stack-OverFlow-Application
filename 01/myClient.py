import socket			

def Get(host, port=8080, path="/", parameters=[]):
    result = ""
    try:
        s = socket.socket()
        s.connect((host, port))
        params = "q=amir&lang=FA"
        a = "GET "+path+" "+params
        s.send(a.encode())	
        result = s.recv(1024).decode()
        s.close()		
    except:
        print("error")
    return result

res = Get("127.0.0.1",12345,"/GetUserInfo")
print(res)