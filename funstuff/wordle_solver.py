import numpy as np
import os
from nltk.corpus import words, brown # A larger one likely exists
import string

n = 5

#common_dict = set ([ elem.lower() for elem in brown.words() if len (elem) == n and all ([c in string.ascii_lowercase for c in elem.lower()]) ])
common_dict = set ([ elem.lower() for elem in words.words() if len (elem) == n and '-' not in elem])

print (len (common_dict))
#print (len (full_dict))

print ("Size of corpus:", len(common_dict))

def letter_pos_prob (letter : chr, corpus : list) :
    counts = [0] * n
    if len (corpus) == 0:
        return []
    for word in corpus:
        for i, c in enumerate (word):
            if letter == c:
                counts[i] += 1
    for i, elem in enumerate (counts):
        counts[i] = elem / len (corpus)
    return counts

def all_letter_probs (corpus) :
    alphabet = string.ascii_lowercase
    probs = dict ([ (letter, letter_pos_prob (letter, corpus)) for letter in alphabet ])
    return probs

#print (all_letter_probs (common_dict))

def get_all_word_probs (corpus):
    letter_probs = all_letter_probs (corpus)
    probs = [ (word, sum ([ letter_probs[letter][i] for i, letter in enumerate (word) ])) for word in corpus ]
    return probs

def get_yellow_prob (letter, corpus):
    count = 0
    if len (corpus) == 0:
        return 0
    for word in corpus:
        if letter in word:
            count += 1
    return count / len(corpus)

def get_all_yellow_probs (corpus):
    return dict ([ (letter, get_yellow_prob (letter, corpus)) for letter in string.ascii_lowercase ])

def yellow_sum (word, yellow_letter_probs):
    return (sum ([ yellow_letter_probs[letter] for i, letter in enumerate (word) if letter not in word[(i+1):] ]))

#print (yellow_sum ("aaaaa", get_all_yellow_probs (common_dict)))

def get_best_yellows (corpus, reverse=True):
    yellow_letter_probs = get_all_yellow_probs (corpus)
    results = [ (word, yellow_sum (word, yellow_letter_probs)) for word in corpus ]
    results.sort (key=lambda tup: tup[1], reverse=reverse)
    return results

#print (get_best_yellows (common_dict)[:10])

# By green score
def get_best_greens (corpus, reverse=True):
    all_word_probs = get_all_word_probs (corpus)
    all_word_probs.sort (key=lambda tup: tup[1], reverse=reverse)
    return all_word_probs
    #return ([ elem for (elem, score) in all_word_probs[:n] ])

#print (get_best_greens (100, common_dict))

def get_wordle_scores (word, corpus):
    green_score = 0
    yellow_score = 0
    if len (corpus) == 0:
        return (0,0)
    for checkWord in corpus:
        for c1, c2 in zip (word, checkWord):
            if c1 == c2:
                green_score += 1
            elif c1 in checkWord:
                yellow_score += 1
    green_score /= len (corpus)
    yellow_score /= len (corpus)
    return (green_score, yellow_score)

#print (get_wordle_scores ("soree", common_dict))

def update_info (info, word, colours):
    word_colours = zip (word, colours)
    for i, (letter, col) in enumerate (word_colours):
        if col == 'f':
            info[letter] = False
        elif col == 'y':
            info[letter] = True
        elif col == 'g':
            info[letter] = i
    return info

def filter_corpus_fully_by_info (info, corpus):
    newCorpus = []
    for word in corpus:
        add = True
        for i, letter in enumerate (word):
            if info[letter] is not None:
                add = False
        if add: newCorpus.append(word)
    return newCorpus

def filter_corpus_partially_by_info (info, corpus):
    newCorpus = []
    for word in corpus:
        add = True
        for i, letter in enumerate (word):
            if (info[letter] is not None) and (type (info[letter]) is int or not info[letter]):
            #if (info[letter] is not None):
                add = False
            #if type(info[letter]) is not int and info[letter]:
            #    add = True
        if add: newCorpus.append(word)
    return newCorpus

#print (len (filter_corpus_fully_by_info (info, common_dict)))

def filter_corpus_by_guess (guess, colours, corpus):
    newCorpus = []
    for word in corpus:
        add = True
        for (colour, g_letter, letter) in zip (colours, guess, word):
            if colour == 'g' and g_letter != letter:
                add = False
            elif colour == 'y' and (g_letter not in word or g_letter == letter):
                add = False
            elif colour == 'f' and g_letter in word:
                add = False
        if add: newCorpus.append (word)
    return newCorpus

def flatten(t):
    return [item for sublist in t for item in sublist]

def sort_yellow_guesses_by_green (yellows, greens):
    greens = dict (greens)
    sorted_yellows = []
    prev_score = -1
    for (word, score) in yellows:
        if score == prev_score:
            sorted_yellows[-1].append ((word, score, greens[word]))
        else:
            sorted_yellows.append ([])
            sorted_yellows[-1].append ((word, score, greens[word]))
        prev_score = score
    for word_list in sorted_yellows:
        word_list.sort (key = lambda elem: greens[elem[0]], reverse=True)
    #[item for sublist in t for item in sublist]
    #print (sorted_yellows)
    return flatten (sorted_yellows)


info = dict ([ (letter, None) for letter in string.ascii_lowercase ])
newCorpus = filter_corpus_by_guess ("point", "ffggf", common_dict)
print (newCorpus)
#print (len (filter_corpus_fully_by_info (info, common_dict)))
#print ("corpus", len (common_dict))
#
#corpus = filter_corpus_by_guess ("raise", "yfffy", common_dict)
#info = update_info (info, "raise", "yfffy")
#print (len (filter_corpus_fully_by_info (info, corpus)))
#print ("corpus", len (corpus))
#
#corpus = filter_corpus_by_guess ("toyer", "fyfgg", corpus)
#info = update_info (info, "toyer", "fyfgg") # older
#print (len (filter_corpus_fully_by_info (info, corpus)))
#print ("corpus", len (corpus))

def play_game (info, corpus, reverse=True):
    os.system("clear -x")
    print ("Play Wordle:")
    print (info)
    print ("There are {0} possible words".format (len(corpus)))
    best_green_guesses = get_best_greens (corpus, reverse)
    best_yellow_guesses = get_best_yellows (corpus, reverse)
    sorted_yellows = sort_yellow_guesses_by_green (best_yellow_guesses, best_green_guesses)

    most_info_corpus = filter_corpus_fully_by_info (info, common_dict)
    print (len (most_info_corpus))
    grey_best_green_guesses = get_best_greens (most_info_corpus, reverse)
    grey_best_yellow_guesses = get_best_yellows (most_info_corpus, reverse)
    grey_sorted_yellows = sort_yellow_guesses_by_green (grey_best_yellow_guesses, grey_best_green_guesses)
    print ("Most info guesses:")
    for elem in grey_sorted_yellows[:10]:
        print(elem)

    yellow_most_info_corpus = filter_corpus_partially_by_info (info, common_dict)
    print (len (yellow_most_info_corpus))
    yellow_grey_best_green_guesses = get_best_greens (yellow_most_info_corpus, reverse)
    yellow_grey_best_yellow_guesses = get_best_yellows (yellow_most_info_corpus, reverse)
    yellow_grey_sorted_yellows = sort_yellow_guesses_by_green (yellow_grey_best_yellow_guesses, yellow_grey_best_green_guesses)
    print ("Most info guesses with yellow:")
    for elem in yellow_grey_sorted_yellows[:10]:
        print(elem)

    print ("Here are my ten best guesses from best to worst, by green priority:")
    for elem in best_green_guesses[:10]:
        print(elem)
    print ("Here are my ten best guesses from best to worst, by yellow priority:")
    for elem in sorted_yellows[:10]:
        print(elem)
    print ("Enter one of them into wordle then write the word here. Or \"quit\" to quit.")
    guess = input()
    if guess == "reverse":
        play_game (info, corpus, not reverse)
    elif guess != "quit":
        print ("Now tell me how well the word did. Write something like \"gyfff\", where an f indicates grey, y yellow and g green:")
        colours = list (input ())
        newCorpus = filter_corpus_by_guess (guess, colours, corpus)
        new_info = update_info (info, guess, colours)
        play_game (new_info, newCorpus, reverse)


play_game (info, common_dict)
