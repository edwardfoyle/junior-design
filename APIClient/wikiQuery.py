import sys
import wptools
import requests
import json

# First, turn the search terms into a MediaWiki Page ID
url = "https://en.wikipedia.org/w/api.php?action=query&prop=info&inprop=url&format=json&redirects&titles="
if len(sys.argv) < 2:
	print("Must include search terms as input")
	sys.exit()
print("Query: ", sys.argv[1])
r = requests.get(url + sys.argv[1])
jsonResult = r.json()
pages = jsonResult["query"]["pages"]
page = pages[list(pages)[0]]
print("Found page: ", page["title"])
print("Page ID: ", page["pageid"])

# Now use the page ID to try to find RA and dec
result = wptools.page(pageid=page["pageid"], silent=True).get_parse()
# print(result.infobox)
print(result.infobox.keys())
print("RA: ", result.infobox["RA"])
print("dec: ", result.infobox["dec"])