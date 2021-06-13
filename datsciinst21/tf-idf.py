import numpy as np
import pandas as pd
from collections import Counter

def tf_idf (all_docs):
    unique_terms = set ([item for sublist in all_docs for item in sublist])

    # Calculating IDF
    idf_dict = dict.fromkeys (unique_terms, 0)
    for doc in all_docs:
        for term, count in Counter(doc).items():
            if count > 0:
                idf_dict[term] += 1

    for term, count in idf_dict.items():
        idf_dict[term] = np.log (len(all_docs)) / count

    tf_idf_list = []
    # Calculating TF
    for doc in all_docs:
        tf_dict = dict.fromkeys (unique_terms, 0)
        tfs = Counter(doc)
        for term, count in tfs.items():
            # Multiplying by idf to get full tf-idf here
            tf_dict[term] = (count / len (doc)) * idf_dict[term]

        tf_idf_list.append(tf_dict)

    return pd.DataFrame (tf_idf_list)


test_doc1 = ["Hello", "world", "world"]
test_doc2 = ["Hello", "wide", "world"]

all_docs = [test_doc1, test_doc2]
test_term = "world"

print (tf_idf (all_docs))
