import pandas as pd
import tokenize

import nltk
from nltk.corpus import stopwords
from nltk.stem import PorterStemmer
from nltk.tokenize import word_tokenize
from cleantext import clean
from sklearn.feature_extraction.text import TfidfVectorizer

data = pd.read_csv("news_sample.csv", nrows=251)
data.to_csv("reduced_sample.csv")
#data = list(data["content"])

#data = [tokenize.generate_tokens(elem) for elem in data] #tokenize.tokenize(data)
'''
tokenized = []
for elem in data:
    clean_text = clean(elem,
                      no_line_breaks=True,
                      no_urls=True,
                      no_punct=True,
                      no_digits=True,
                      no_currency_symbols=True,
                      replace_with_url="",
                      replace_with_email="",
                      replace_with_phone_number="",
                      replace_with_number="",
                      replace_with_digit="",
                      replace_with_currency_symbol="")

    tokens = word_tokenize(clean_text)
    tokenized.append(tokens)

print (tokenized[0])

vect = TfidfVectorizer()
content_tfidf = vect.fit_transform(data["content"])
print (content_tfidf.shape)
print (content_tfidf[0].shape)
print (data["content"]
pd.DataFrame(tokenized).to_csv("tokenized.csv")
'''
