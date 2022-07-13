import sqlite3

from matplotlib.style import use
from sqlalchemy import false, true
conn = sqlite3.connect('AlphA.db')
import datetime as dt

# c = conn.cursor()
# c.execute("""CREATE TABLE User (
#     id integer primary key autoincrement,
#     name text,
#     last text,
#     username text,
#     email text,
#     time_sign text,
#     password text,
#     sex text
#     )""")


# c.execute("""CREATE TABLE Question (
#     id integer primary key autoincrement,
#     userid integer,
#     head text,
#     Describ text
#     )""")
# conn.commit()
# c.execute("""CREATE TABLE Tag (
#     id integer primary key autoincrement,
#     name text
#     )""")
# c.execute("""CREATE TABLE Question_Tag (
#     id integer primary key autoincrement,
#     qid integer,
#     Tid integer
#     )""")

# c.execute("""CREATE TABLE Answer (
#     id integer primary key autoincrement,
#     qid integer,
#     userid integer,
#     Describ text,
#     voteup integer,
#     votedown integer
#     )""")

# c.execute("""CREATE TABLE intrested (
#     id integer primary key autoincrement,
#     userid integer,
#     tagid integer
#     )""")

# c.execute("alter table Question add column isdelete 'integer'")
# c.execute("alter table Question add column view 'integer'")
# c.execute("alter table Question add column answer 'integer'")

# c.execute("""CREATE TABLE Answer_Like (
#     id integer primary key autoincrement,
#     userid integer,
#     aid integer,
#     value integer
#     )""")

# c.execute("""CREATE TABLE View (
#     id integer primary key autoincrement,
#     userid integer,
#     qid integer
#     )""")

# conn.commit()






# ////////////////////////////////////////////////////////////////////////

def Get_User_Info_By_username_db(username):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    c.execute(f"SELECT * FROM User WHERE username = :username",{'username':username})
    b = c.fetchone()
    conn.close()
    # print(b)
    
    if b:
        return b
    else:
        return False

def Get_User_Info_By_email_db(email):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    c.execute(f"SELECT * FROM User WHERE email = :email",{'email':email})
    b = c.fetchone()
    conn.close()
    
    if b:
        return b
    else:
        return False



def Get_User_Info_By_uid(uid):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    c.execute(f"SELECT * FROM User WHERE id = :id",{'id':uid})
    b = c.fetchone()
    conn.close()
    
    if b:
        return b
    else:
        return False



def sign_up_db(p):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    # print(admin)
    with conn:
        c.execute("INSERT INTO User ( name , last , username , email , time_sign , password , sex ) VALUES (?,?,?,?,?,?,?)", (
                 p['name'] ,  p['lastname'] , p['username'] ,  p['email'] , str(dt.datetime.now()) ,  p['password'] ,  p['sex'] ))
    numbertags = p['tagnumbers']
    rowid = c.lastrowid
    with conn:
        c.execute("Select * From User WHERE rowid = :rowid", {"rowid" : rowid})
    
    b = c.fetchone()
    uid = b[0]
    for i in range(int(numbertags)):
        with conn:
            c.execute("INSERT INTO intrested ( userid , tagid  ) VALUES (?,?)", (uid , p["Tid" + str(i)]))


    conn.close()




def Get_NQuestions(p):
    # print(p)
    username = p["username"]
    filter1 = p["filter1"]
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    if filter1 == "My intrested's" :
        c.execute(f"SELECT * FROM User WHERE username = :username",{'username':username})
        user = c.fetchone()
        # print(user)
        c.execute(f"SELECT tagid FROM intrested WHERE userid = :userid",{'userid':user[0]})
        
        tags = c.fetchall()
        print("tags : " , tags)
        tags2 =[]

        for i in tags:
            tags2.append(i[0])
        
        tags2 = tuple(tags2)
        # print(tags)
        # "SELECT qid FROM Question_Tag  WHERE Tid in ({seq}) ORDER BY rowid DESC LIMIT 10".format(seq=','.join(['?']*len(tags)))
        c.execute("SELECT qid FROM Question_Tag  WHERE Tid in ({seq})".format(seq=','.join(['?']*len(tags2))) , tags2)

        qidlist = c.fetchall()
        print("qidlist : " , qidlist)
        # print(qidlist)
        qidlist2 = []
        for i in qidlist:
            qidlist2.append(i[0])
        
        print("qidlist2 : " , qidlist2)
        # print(qidlist2)
        # "SELECT * FROM Question  WHERE qid in ({seq}) ORDER BY rowid DESC LIMIT 10".format(seq=','.join(['?']*len(qidlist)))
        c.execute("SELECT * FROM Question  WHERE id in ({seq}) AND isdelete = 0 ORDER BY rowid DESC LIMIT 10".format(seq=','.join(['?']*len(qidlist2))) , tuple(qidlist2))
        b = c.fetchall()
        print("b : " , b)
    elif filter1 == "Most View":
        c.execute("SELECT * FROM Question  WHERE  isdelete = 0 ORDER BY view DESC LIMIT 10")
        b = c.fetchall()
        

    else :
        c.execute("SELECT * FROM Question Where isdelete = 0 ORDER BY rowid DESC LIMIT 10")
        b = c.fetchall()
    
    conn.close()
    if b:
        return b 
    else:
        return []




def Get_NMyQuestions(p):
    print(p)
    numberq = 0
    numberA = 0 
    lenmosbat = 0 
    lenmanfi = 0
    
    username = p["username"]
    
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    
    c.execute(f"SELECT * FROM User WHERE username = :username",{'username':username})
    user = c.fetchone()
    print(user)
    
    
    c.execute("SELECT * FROM Question WHERE userid = :userid AND isdelete = 0 ORDER BY rowid DESC LIMIT 10" , {"userid" : user[0]})
    b = c.fetchall()
    c.execute("SELECT COUNT(*) FROM Question WHERE userid = :userid AND isdelete = 0 " , {"userid" : user[0]})
    b2 = c.fetchone()
    
    
    # print("b2 : ", b2)
    numberq = b2[0]
    c.execute("SELECT COUNT(*) FROM Answer WHERE userid = :userid AND isdelete = 0" , {"userid" : user[0]})
    b2 = c.fetchone()
    numberA = b2[0]

    c.execute("SELECT COUNT(*) FROM Answer_Like WHERE userid = :userid AND value = -1" , {"userid" : user[0]})
    manfi = c.fetchall()
    c.execute("SELECT COUNT(*) FROM Answer_Like WHERE userid = :userid AND value = 1" , {"userid" : user[0]})
    mosbat = c.fetchall()

    for i in range(len(b)) :
        c.execute("SELECT COUNT(*) FROM Answer WHERE qid = :qid AND isdelete = 0" , {"qid" : b[i][0]})

        numberans = c.fetchone()[0]
        
        b[i] = b[i] + (numberans,)
        



    if len(manfi) > 1:
        lenmanfi = len(manfi)
    else:
        lenmanfi = 0
    if len(mosbat) > 1 :
        lenmosbat = len(mosbat)
    else:
        lenmosbat = 0




    
    conn.close()
    
    # if b:
    return b , numberq , numberA , lenmosbat , lenmanfi , user
    # else:
    #     return [] , 0 , 0 , 0 , 0 , []




def GetNUsers_db():
    # username = p["username"]


    
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()


    
    c.execute(f"SELECT * FROM User ORDER BY rowid DESC LIMIT 20")
    users = c.fetchall()
    dict01 = {}
    dict01["number"] = len(users)
    for i in range(len(users)):
        dict01["name" + str(i)] = users[i][1]
        dict01["last" + str(i)] = users[i][2]
        dict01["username" + str(i)] = users[i][3]
        dict01["email" + str(i)] = users[i][4]
        x ,dict01["numberQ" + str(i)] , dict01["numberA" + str(i)] , dict01["mosbat" + str(i)] , dict01["manfi" + str(i)] , z = Get_NMyQuestions({"username":users[i][3]})
    



    




    
    conn.close()
    
    return dict01



def Get_NQuestions_Tags(qid):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    c.execute(f"SELECT * FROM Question_Tag WHERE qid = :qid",{'qid':qid})
    b = c.fetchall()
    # conn.close()
    tags = ""
    for i in b:
        v = i
        # c = conn.cursor()
        c.execute(f"SELECT * FROM Tag WHERE id = :Tid",{'Tid':i[2]})
        f = c.fetchone()
        tags+= f[1] + '<*****>'

        # conn.close()
    conn.close()
    if b:
        return tags
    else:
        return 'False'



def Get_Special_Tags_Question_db(name_tag , username):
    
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    
    c.execute(f"SELECT id FROM Tag WHERE name = :name",{'name':name_tag})
    tag = c.fetchone()
    # print(tag)


    c.execute(f"SELECT * FROM Question_Tag WHERE Tid = :Tid",{'Tid':tag[0]})
    qt0 = c.fetchall()
    qt1 = qt0
    
    number = len(qt0)

    if number > 10:
        qt1 = qt0[-10]
    # print(qt1)
    
    q0 = []
    for i in qt1:
        q0.append(i[1])
    
    # print(q0)
    c.execute("SELECT * FROM Question  WHERE id in ({seq}) AND isdelete = 0 ORDER BY rowid DESC LIMIT 10".format(seq=','.join(['?']*len(q0))) , tuple(q0))
    b = c.fetchall()
    # print("b :" ,  b)

    User = Get_User_Info_By_username_db(username)
    # print(User[0] ,'    ', tag[0])
    c.execute("SELECT * FROM intrested  WHERE userid = :userid And tagid = :tagid" , {"userid" : User[0] , "tagid" : tag[0]})

    b2 = c.fetchall()
    b3 = "false"
    # print("b2 :::::::    " , b2)
    if len(b2) >= 1:
        b3 = "true"
    



    conn.close()
    
    if b:
        return b , number , b3
    else:
        return False , None , "false"




def Change_intresteds(p):
    name_tag = p["tag"]
    username = p["username"]
    state = p["state"]
    
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    
    c.execute(f"SELECT id FROM Tag WHERE name = :name",{'name':name_tag})
    tag = c.fetchone()
    # print(tag)
    User = Get_User_Info_By_username_db(username)

    if(state == "delete"):
        c.execute("DELETE From intrested WHERE userid = :userid AND tagid = :tagid" , {"userid" : User[0] , "tagid" : tag[0]})
        conn.commit()
    elif(state == "add"):
        c.execute("INSERT INTO intrested ( userid , tagid  ) VALUES (?,?)", (
                    User[0] , tag[0]))
        conn.commit()



    


    conn.close()
    
    return 'true'

    

    

        




        


def Get_Questions_Answer(qid , username):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    c.execute(f"SELECT * FROM Question WHERE id = :qid AND isdelete = 0",{'qid':qid})
    b = c.fetchone()
    q = b
    # conn.close()
    
    
    c.execute(f"SELECT * FROM Answer WHERE qid = :qid AND isdelete = 0",{'qid':qid})
    b = c.fetchall()
    User = Get_User_Info_By_username_db(username)

    c.execute(f"SELECT * FROM View WHERE qid = :qid And userid = :userid ",{'qid':qid , "userid" : User[0]})

    b3 = c.fetchall()

    if len(b3) >= 1:
        pass
    else:
        with conn:
            c.execute("INSERT INTO View ( qid , userid  ) VALUES (?,?)", (
                    qid , User[0]))

        with conn:
            c.execute("UPDATE Question SET view = view + 1 Where id = :id",{"id" : qid})
                    

        

    c.execute(f"SELECT COUNT(*) FROM View WHERE qid = :qid ",{'qid':qid })
    b2 = c.fetchone()[0]



    



    



    

    # conn.close()
    conn.close()
    if q:
        return q , b , b2
    else:
        return None , None , None

def Get_Tags_db():
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    c.execute(f"SELECT * FROM Tag")
    b = c.fetchall()
    conn.close()
    # print(b)
    
    if b:
        return b
    else:
        return False


def Get_Usernames_db():
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    c.execute(f"SELECT * FROM User")
    b = c.fetchall()
    conn.close()
    # print(b)
    
    if b:
        return b
    else:
        return False




def Post_Question_db(p):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    # print(admin)
    with conn:
        c.execute("INSERT INTO Question ( userid , head , Describ , isdelete  ) VALUES (?,?,?,?)", (
                 p['userid'] ,  p['head'] , p['Describ'] , 0))
    
    


    rowid = c.lastrowid
    with conn:
        c.execute("Select * From Question WHERE rowid = :rowid", {"rowid" : rowid})
    
    b = c.fetchone()
    qid = b[0]

    
    for i in range(int(p['number'])):
        with conn:
            c.execute("INSERT INTO Question_Tag ( qid , Tid  ) VALUES (?,?)", (
                    qid ,  p[f'Tid{str(i)}'] ))


        
    conn.close()

    return qid




def Insert_Tag_db(p):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    # print(admin)
    

    with conn:
        c.execute("INSERT INTO Tag (name) VALUES (?)", (p,))
        
    conn.close()




def Delete_question_db(p):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    # print(admin)
    
    # print(p)
    with conn:
        c.execute("UPDATE Question SET isdelete = :one Where id = :id" , {"id" : int(p[0][1]) , "one" : 1})
        

    
        
    conn.close()

    return true


def Delete_Answer_db(p):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    # print(admin)
    
    # print(p)
    with conn:
        c.execute("UPDATE Answer SET isdelete = :one Where id = :id" , {"id" : int(p["aid"]) , "one" : 1})
        

    
        
    conn.close()

    return true


def caculate_vote_db(aid):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()

    with conn:
        c.execute("Select * From Answer_Like WHERE aid = :aid", {"aid" : int(aid)})
    
    b = c.fetchall()
    print("b ::: " , b)
    if len(b) > 0 :
        res = 0
        for i in b:
            res += i[3]
        
        return res
    else:
        return 0




def Get_vote_db(p):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    # print(admin)
    # print("parameters = = = = = " , p)
    user = Get_User_Info_By_username_db(p["username"])
    with conn:
        c.execute("Select * From Answer_Like WHERE aid = :aid AND userid = :userid", {"aid" : int(p["aid"]) , "userid" : user[0]})
    
    votes = c.fetchall()
    print("votes : " , votes)

    # print(votes)

    
    print("User : " , user)
    print("param : " , p)

    if len(votes) >= 1:
        for i in votes:
            if user[0] == i[1]:
                if i[3] == 1 and p["vote"] == "up":
                    return "upbefore"
                    break
                elif i[3] == 1 and p["vote"] == "down":
                    # print(user[0])
                    # print(p["aid"])
                    c.execute("UPDATE Answer_Like SET value =-1 Where aid = :aid AND userid = :userid" , {"aid" : int(p["aid"]) , "userid" : user[0]})
                    conn.commit()
                    return "downnow"
                elif i[3] == -1 and p["vote"] == "down" :
                    return "downbefore"
                    break
                elif i[3] == -1 and p["vote"] == "up" :
                    c.execute("UPDATE Answer_Like SET value = :one Where aid = :aid AND userid = :userid" , {"aid" : int(p["aid"]) , "one" : 1 , "userid" : user[0]})
                    conn.commit()
                    return "upnow"
    else:
        print("test4")
        if(p["vote"] == "up"):
            print("tets1")

            with conn:
                c.execute("INSERT INTO Answer_Like ( userid , aid , value ) VALUES (?,?,?)", (
                        user[0] ,  p['aid'] , 1 ))
            
            return "upnow"
        else:
            print("tets12")
            with conn:
                c.execute("INSERT INTO Answer_Like ( userid , aid , value ) VALUES (?,?,?)", (
                        user[0] ,  p['aid'] , -1 ))
            
            return "downnow"
    
    print("tets3")


def post_Answer_db(p):
    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    # print(admin)
    user = Get_User_Info_By_username_db(p["username"])

    with conn:
        c.execute("INSERT INTO Answer ( qid , userid , Describ , isdelete ) VALUES (?,?,?,?)", (
                 p['qid'] ,  user[0] , p['Describ'] , 0))

    conn.close()

    return 'true'


def Get_tag_info_form_db():

    conn = sqlite3.connect('AlphA.db')
    c = conn.cursor()
    c.execute(f"SELECT * FROM Tag")
    dict01 = {}
    b = c.fetchall()

    dict01["number"] = len(b)

    for i in range(len(b)):

        c.execute("SELECT COUNT(*) FROM Question_Tag  WHERE Tid = :tagid",{"tagid" : b[i][0]})
        n = c.fetchone()[0]
        dict01["tag" + str(i)] = b[i][1]
        dict01["asked" + str(i)] = n
    


    return dict01




    
    
    



    
    



    