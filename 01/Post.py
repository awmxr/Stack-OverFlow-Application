import urllib.parse	
from Database import AlphAdb
import Function
import Get
import Setting

def SignUp(p,que):
    parametrs = urllib.parse.parse_qsl(p)
    # print(parametrs)
    parametrs = dict(parametrs)
    # print(parametrs)

    username = parametrs["username"]
    password = parametrs["password"]
    name = parametrs["name"]
    lastname = parametrs["lastname"]
    email = parametrs["email"]

    print(parametrs)


    User = AlphAdb.Get_User_Info_By_username_db(username)

    if User :
        result = "This Username taken"
        que.put(result)
        return "This Username taken"

    User = AlphAdb.Get_User_Info_By_email_db(email)
    if User :
        result = "This email already have a account"
        que.put(result)
        return "This email already have a account"

    
    tag_list3 = AlphAdb.Get_Tags_db()
    tag_list = []
    for i in tag_list3:
        tag_list.append(i[1])

    tag_list2 = []
    for i in range(int(parametrs["tagnumbers"])):
        tag_list2.append(parametrs[f"tag{str(i)}"])
    
    for i in tag_list2:
        print(i)

        if i.lower() not in tag_list:
            AlphAdb.Insert_Tag_db(i.lower())
    

    tag_list3 = AlphAdb.Get_Tags_db()

    tagsdict = {}
    for i in tag_list3:
        tagsdict[i[1]] = i[0]


    for i in range(len(tag_list2)):
        
        parametrs[f"Tid{str(i)}"] = tagsdict[tag_list2[i]]

    AlphAdb.sign_up_db(parametrs)

    User = AlphAdb.Get_User_Info_By_username_db(username)

    if User :
        result = 'Sign Up Complete'
        que.put(result)
        return 'Sign Up Complete'
    
    result = "false"
    que.put(result)
    return "false"


def Post_Question(p,que):
    parametrs = urllib.parse.parse_qsl(p)
    # print(parametrs)
    parametrs = dict(parametrs)
    # print(parametrs)
    print(parametrs)
    username = parametrs["username"]
    head = parametrs["head"]
    describ = parametrs["Describ"]
    number_tag = parametrs["number"]

    User = AlphAdb.Get_User_Info_By_username_db(username)
    
    userid = User[0]
    parametrs["userid"] = userid

    tag_list3 = AlphAdb.Get_Tags_db()
    tag_list = []
    for i in tag_list3:
        tag_list.append(i[1])

    tag_list2 = []
    for i in range(int(parametrs["number"])):
        tag_list2.append(parametrs[f"tag{str(i)}"])
    
    for i in tag_list2:
        print(i)

        if i.lower() not in tag_list:
            AlphAdb.Insert_Tag_db(i.lower())
    

    tag_list3 = AlphAdb.Get_Tags_db()

    tagsdict = {}
    for i in tag_list3:
        tagsdict[i[1]] = i[0]


    for i in range(len(tag_list2)):
        
        parametrs[f"Tid{str(i)}"] = tagsdict[tag_list2[i]]

    print(parametrs)
    qid = AlphAdb.Post_Question_db(parametrs)




        





    # result = "true"

    # que.put(result)
    # result2 = Get.Send_NQuestions2()
    
    result2 = "Get{Setting.Split_char}/SendUpdateQuestions"
    # clinetsConcted = None
    # while(clinetsConcted == None):
    #     clinetsConcted = Function.q3.get()

    # for i in clinetsConcted.Values():
    #     i[0].send((result2 +"<SSFINSS>").encode())
    
    dict01 = {"qid" : qid , "res" : "true"}
    print(dict01)
    params = urllib.parse.urlencode(dict01)

    result = f"POST{Setting.Split_char}/PostQuestion{Setting.Split_char}{params}"

    print(result)
    # que.put(result)

    # res = "false"
    que.put(result)
    return result

    # return "true" , qid



def Post_Answer(p,que):
    parametrs = dict(urllib.parse.parse_qsl(p))
    print("parametrs : " , parametrs)
    


    b = AlphAdb.post_Answer_db(parametrs)
    
    dict01 = {'state':b }
    

    
    
        
    
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/PostAnswer{Setting.Split_char}{params}"

    print(result)
    que.put(result)
    return result

    