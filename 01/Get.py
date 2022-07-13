from unittest import result
import urllib.parse

from matplotlib.style import use	
from Database import AlphAdb
import Setting
import queue


def GetUserInfo(p , que):
    res = "hi baby, Parameters you send to me: "+p

    que.put(res)
    return "hi baby, Parameters you send to me: "+p



def LoginUser(p,que):
    parametrs = urllib.parse.parse_qsl(p)
    # print(parametrs)
    parametrs = dict(parametrs)
    # print(parametrs)

    username = parametrs["username"]
    password = parametrs["password"]
    res = "false"
    User = AlphAdb.Get_User_Info_By_username_db(username)
    # print("user : ",username)
    if User :
        if password == User[6]:
            # print(password)
            # print(User[6])
            # print("[w][ew[ew]e[]w[eq][e]qw[eqw]e[")
            res = "true"
            # que.put(res)
            # return "true"
    dict01 = {"res" : res}
    # print(dict01)
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/LoginUser{Setting.Split_char}{params}"

    # print(result)
    # que.put(result)

    # res = "false"
    que.put(result)
    return result




    # print("user : ",username)
    # print("pass : ",password)

def Send_NQuestions(p,que):
    parametrs = urllib.parse.parse_qsl(p)
    # print(parametrs)
    parametrs = dict(parametrs)
    b = AlphAdb.Get_NQuestions(parametrs)
    # b = b[-15]
    dict01 = {'number':len(b)}
    # print(b)
    
    for i in range(len(b)):
        
        dict01[f'qid{str(i)}'] = str(b[i][0])
        username = AlphAdb.Get_User_Info_By_uid(b[i][1])[3]
        dict01[f'userid{str(i)}'] = username
        dict01[f'head{str(i)}'] = str(b[i][2])
        dict01[f'describ{str(i)}'] = str(b[i][3])
        tags = AlphAdb.Get_NQuestions_Tags(b[i][0])
        # print(tags,"\n\n\n\n\n\n\ntaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaag\n\n\n\\n\\n\n")
        dict01[f'tags{str(i)}'] = tags
    
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/SendNQuestions{Setting.Split_char}{params}"
    que.put(result)

    return result



def Send_NMyQuestions(p,que):
    parametrs = urllib.parse.parse_qsl(p)
    # print(parametrs)
    parametrs = dict(parametrs)
    b , numberQ , numberA , mosbat , manfi , user = AlphAdb.Get_NMyQuestions(parametrs)
    # b = b[-15]
    print("user :" , user)
    dict01 = {'number':len(b) , "mosbat" : mosbat , "manfi" : manfi , "email" : user[4] , "username" : user[3],"name" : user[1] , "last" : user[2]}
    # print(b)
    
    for i in range(len(b)):
        
        dict01[f'qid{str(i)}'] = str(b[i][0])
        username = AlphAdb.Get_User_Info_By_uid(b[i][1])[3]
        dict01[f'userid{str(i)}'] = username
        dict01[f'head{str(i)}'] = str(b[i][2])
        dict01[f'describ{str(i)}'] = str(b[i][3])
        dict01[f'view{str(i)}'] = str(b[i][5])
        dict01[f'numbera{str(i)}'] = str(b[i][6])
        tags = AlphAdb.Get_NQuestions_Tags(b[i][0])
        # print(tags,"\n\n\n\n\n\n\ntaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaag\n\n\n\\n\\n\n")
        dict01[f'tags{str(i)}'] = tags
    dict01["numberq"] = numberQ
    dict01["numbera"] = numberA
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/SendNMyQuestions{Setting.Split_char}{params}"
    que.put(result)

    return result


def GetNUsers(p,que):
    # parametrs = urllib.parse.parse_qsl(p)
    # print(parametrs)
    # parametrs = dict(parametrs)
    dict01 = AlphAdb.GetNUsers_db()
    
    
    
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/GetNUsers{Setting.Split_char}{params}"
    que.put(result)

    return result







def Get_Vote(p,que):

    parametrs = dict(urllib.parse.parse_qsl(p))
    # print("parametrs : " , parametrs)
    

    res = AlphAdb.Get_vote_db(parametrs)
    votes = AlphAdb.caculate_vote_db(int(parametrs["aid"]))

    dict01 = {'state':res , 'votes' : votes }


    
    # q , b = AlphAdb.Get_Questions_Answer(qid)
    
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/GetVotes{Setting.Split_char}{params}"

    que.put(result)
    return result


def Get_Question_Answer(p,que):
    parametrs = dict(urllib.parse.parse_qsl(p))
    # print("parametrs : " , parametrs)
    qid = parametrs['qid']
    username = parametrs["username"]


    q , b , view = AlphAdb.Get_Questions_Answer(qid , username)
    # print("bbbbbbbb , " , b)
    
    dict01 = {'number':len(b) , 'head' : q[2] , 'describ' : q[3] }
    dict01['username'] = AlphAdb.Get_User_Info_By_uid(q[1])[3]
    dict01["view"] = view


    
    for i in range(len(b)):
        
        dict01[f'aid{str(i)}'] = str(b[i][0])
        username = AlphAdb.Get_User_Info_By_uid(b[i][2])[3]
        dict01[f'userid{str(i)}'] = username
        dict01[f'answer{str(i)}'] = str(b[i][3])
        dict01[f'voteup{str(i)}'] = str(b[i][4])
        dict01[f'votedown{str(i)}'] = str(b[i][5])
        dict01[f'vote{str(i)}'] = AlphAdb.caculate_vote_db(b[i][0])
    
        
    
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/SendQuestionAnswer{Setting.Split_char}{params}"

    # print(result)
    que.put(result)
    return result



def Get_Tags(p,que):
    b = AlphAdb.Get_Tags_db()

    dict01 ={"number" : len(b)}

    for i in b:
        dict01[i[1]] = i[0]
    

    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/SendTags{Setting.Split_char}{params}"

    # print(result)
    que.put(result)
    return result

def Get_Usernames(p,que):
    b = AlphAdb.Get_Usernames_db()

    dict01 ={"number" : len(b)}

    for i in b:
        dict01[i[3]] = i[0]
    

    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/SendTags{Setting.Split_char}{params}"

    # print(result)
    que.put(result)
    return result


def Get_Tags2():
    b = AlphAdb.Get_Tags_db()

    dict01 ={"number" : len(b)}

    for i in b:
        dict01[i[1]] = i[0]
    

    params = urllib.parse.urlencode(dict01)
    # result = f"Get{Setting.Split_char}/SendTags{Setting.Split_char}{params}"

    # print(dict01)
    return params


def Send_NQuestions2():
    b = AlphAdb.Get_NQuestions()
    dict01 = {'number':len(b)}
    # print(b)
    
    for i in range(len(b)):
        
        dict01[f'qid{str(i)}'] = str(b[i][0])
        username = AlphAdb.Get_User_Info_By_uid(b[i][1])[3]
        dict01[f'userid{str(i)}'] = username
        dict01[f'head{str(i)}'] = str(b[i][2])
        dict01[f'describ{str(i)}'] = str(b[i][3])
        tags = AlphAdb.Get_NQuestions_Tags(b[i][0])
        # print(tags,"\n\n\n\n\n\n\ntaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaag\n\n\n\\n\\n\n")
        dict01[f'tags{str(i)}'] = tags
    
    params = urllib.parse.urlencode(dict01)
    # result = f"Get{Setting.Split_char}/SendUpdateQuestions{Setting.Split_char}{params}"
    

    return params


# def Get_Question_Answer(qid):
    
    
    


#     q , b = AlphAdb.Get_Questions_Answer(qid)
    
#     dict01 = {'number':len(b) , 'head' : q[2] , 'describ' : q[3] }
#     dict01['username'] = AlphAdb.Get_User_Info_By_uid(q[1])[3]

    
#     for i in range(len(b)):
        
#         dict01[f'aid{str(i)}'] = str(b[i][0])
#         username = AlphAdb.Get_User_Info_By_uid(b[i][2])[3]
#         dict01[f'userid{str(i)}'] = username
#         dict01[f'answer{str(i)}'] = str(b[i][3])
#         dict01[f'voteup{str(i)}'] = str(b[i][4])
#         dict01[f'votedown{str(i)}'] = str(b[i][5])
        
    
#     params = urllib.parse.urlencode(dict01)
#     # result = f"Get{Setting.Split_char}/SendQuestionAnswer{Setting.Split_char}{params}"

    
    
#     return params

def Get_Update(p , que):

    dict01 = {}
    parametrs = urllib.parse.parse_qsl(p)
    tags = None
    questions = None
    if("Tags" in parametrs.keys()):
        tags = Get_Tags2()
    
    if("Questions" in parametrs.keys()):
        questions = Send_NQuestions2()

    dict01["Questions"] = questions
    dict01["Tags"] = tags
    for i in parametrs:
        if("Tags" == parametrs[i] or "Questions" == parametrs[i]):
            continue

        dict01[i] = Get_Question_Answer(int(parametrs[i]))
    

    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/SendUpdate{Setting.Split_char}{params}"
    que.put(result)
    return result


def delete_Question(p , que):

    dict01 = {}
    # parametrs = urllib.parse.parse_qsl(p)
    parametrs = urllib.parse.parse_qsl(p)
    res = AlphAdb.Delete_question_db(parametrs)
    dict01 = {'res':res}
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/DeleteQuestion{Setting.Split_char}{params}"
    que.put(result)
    return result


def delete_Answer(p , que):

    dict01 = {}
    # parametrs = urllib.parse.parse_qsl(p)
    parametrs = dict(urllib.parse.parse_qsl(p))
    res = AlphAdb.Delete_Answer_db(parametrs)
    dict01 = {'res':res}
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/DeleteAnswer{Setting.Split_char}{params}"
    que.put(result)
    return result

def GetSpecialTagsQuestion(p , que):
    parametrs = urllib.parse.parse_qsl(p)
    # print(parametrs)
    parametrs = dict(parametrs)
    b , number , intres = AlphAdb.Get_Special_Tags_Question_db(parametrs["tag"] , parametrs["username"])
    # b = b[-15]
    dict01 = {'number':len(b) , "intres" : intres}
    # print(b)
    
    for i in range(len(b)):
        
        dict01[f'qid{str(i)}'] = str(b[i][0])
        username = AlphAdb.Get_User_Info_By_uid(b[i][1])[3]
        dict01[f'userid{str(i)}'] = username
        dict01[f'head{str(i)}'] = str(b[i][2])
        dict01[f'describ{str(i)}'] = str(b[i][3])
        tags = AlphAdb.Get_NQuestions_Tags(b[i][0])
        # print(tags,"\n\n\n\n\n\n\ntaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaag\n\n\n\\n\\n\n")
        dict01[f'tags{str(i)}'] = tags
    
    dict01["specialtag"] = parametrs["tag"]

    dict01["numberq"] = number
    
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/GetSpecialTagsQuestion{Setting.Split_char}{params}"
    que.put(result)

    return result


def GetNTagsForm(p , que):
    
    dict01 = AlphAdb.Get_tag_info_form_db()
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/GetNTagsForm{Setting.Split_char}{params}"
    que.put(result)

    return result









def Change_intrested(p , que):
    parametrs = urllib.parse.parse_qsl(p)
    # print(parametrs)
    parametrs = dict(parametrs)
    b  = AlphAdb.Change_intresteds(parametrs)
    # b = b[-15]
    dict01 = {'res':b}
    # print(b)
    
    
    
    params = urllib.parse.urlencode(dict01)
    result = f"Get{Setting.Split_char}/Changeintrested{Setting.Split_char}{params}"
    que.put(result)

    return result




    




        
    
        
        






    


