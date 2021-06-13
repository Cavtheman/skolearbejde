import pandas as pd
import numpy as np
import torch
from torch.utils import data
from nltk.tokenize import word_tokenize
from cleantext import clean
from sklearn.preprocessing import OneHotEncoder

class FakeNewsDataset(data.Dataset):
    # Quick function to generate a OneHot encoding dictionary given a list of labels
    # There are several libraries that do this but I was lazy
    def __onehot_encoder__(self, labels):
        encoding_dict = {}
        for i, elem in enumerate (labels):
            temp = torch.zeros (len (labels))
            temp[i] = 1
            encoding_dict[elem] = temp
        return encoding_dict

    def __init__(self, data_path, embedding_path, labels):
        self.data_path = data_path
        self.embedding_path = embedding_path

        self.cleaning_args = {
            "no_line_breaks": True,
            "no_urls": True,
            "no_punct": True,
            "no_digits": True,
            "no_currency_symbols": True,
            "replace_with_url":  "",
            "replace_with_email": "",
            "replace_with_phone_number": "",
            "replace_with_number": "",
            "replace_with_digit": "",
            "replace_with_currency_symbol": ""
        }

        # Loading the GloVe embeddings from file
        self.embedding_dict = {}
        with open(embedding_path, 'r') as f:
            for line in f:
                values = line.split()
                word = values[0]
                vector = np.asarray(values[1:], "float64")
                self.embedding_dict[word] = vector
        self.embedding_dim = next (iter(self.embedding_dict.values())).shape

        # Since I'm looking at more that one label, I'm using a OneHot encoding
        # Transforms each label ("reliable, bias, etc")
        self.label_dict = self.__onehot_encoder__ (labels)

    # Required function for the Dataset class
    # Should return the length of the dataset
    def __len__(self):
         return pd.read_csv (self.data_path, usecols=["id"]).shape[0]

    # Self-defined method that gets the GloVe embedding of a given word
    # If a word isn't in the dictionary, it is added with a zero-vector value
    def __get_embedding__(self, word):
        if word not in self.embedding_dict:
            self.embedding_dict[word] = np.zeros(self.embedding_dim)

        return self.embedding_dict[word]

    # Required method for the Dataset class.
    # Takes an index of the dataset, and should return a single example of data, and a label
    # You will want to probably change this significantly if you implement this yourself
    # (You can actually return anything here, and for unsupervised learning you don't have a label)
    # Note that the data is not preprocessed or cleaned thoroughly here. You will want to do that
    def __getitem__(self, index):
        # Getting just a single line from the csv file
        # You can likely do something similar for your SQL database by querying for a single id
        data = pd.read_csv (self.data_path, skiprows=range (1,index+1), nrows=1, usecols=["content","type"])

        # Note that the label here is a onehot encoding of all the types in the fake news corpus
        # It is NOT just true/fake
        label = data.values[0][0]
        data = data.values[0][1]

        # Minimal cleaning and tokenizing
        clean_text = clean(data, **self.cleaning_args)
        data = word_tokenize(clean_text)

        # Getting the embeddings and turning it into a pytorch tensor
        data = [ self.__get_embedding__ (word) for word in data ]
        data = torch.from_numpy (np.stack (data)).float()

        # Hack to remove nan values. Don't do this :)
        if type(label) == float:
            label = "unreliable"

        label = self.label_dict[label].long()
        return data, label


#test = Dataset ("news_sample.csv", "glove.6B.50d.txt")
