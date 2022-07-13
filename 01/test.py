import urllib.parse

# import urllib2
dict01 = {'hello':'there', 'foo': 'bar'}
dict02 = {'a' : {'hello':'there', 'foo': 'bar'} , 'b' : {'hello':'there', 'foo': 'bar'}}
params = urllib.parse.urlencode(dict01)
z = urllib.parse.parse_qsl(params)
print(params)
print(dict(z))
# print(params)