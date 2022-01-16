import numpy as np
import os
from nltk.corpus import words # A larger one likely exists
import string

n = 5

filtered_set = [ elem.lower() for elem in words.words() if len (elem) == n ]

print ("Size of corpus:", len(filtered_set))

def letter_pos_prob (letter : chr, corpus : list) :
    counts = [0] * n
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

#print (all_letter_probs (filtered_set))

def get_all_word_probs (corpus):
    letter_probs = all_letter_probs (corpus)
    probs = [ (word, sum ([ letter_probs[letter][i] for i, letter in enumerate (word) ])) for word in corpus ]
    #probs = []
    #for word in corpus:
    #    score = sum ([ letter_probs[letter][i] for i, letter in enumerate (word) ])
    #    probs.append ((word,score))
    return probs

def get_yellow_prob (letter, corpus):
    count = 0
    for word in corpus:
        if letter in word:
            count += 1
    return count / len(corpus)

def get_all_yellow_probs (corpus):
    return dict ([ (letter, get_yellow_prob (letter, corpus)) for letter in string.ascii_lowercase ])

def yellow_sum (word, yellow_letter_probs):
    return (sum ([ yellow_letter_probs[letter] for i, letter in enumerate (word) if letter not in word[(i+1):] ]))

print (yellow_sum ("aaaaa", get_all_yellow_probs (filtered_set)))

def get_best_yellows (corpus):
    yellow_letter_probs = get_all_yellow_probs (corpus)
    results = [ (word, yellow_sum (word, yellow_letter_probs)) for word in corpus ]
    results.sort (key=lambda tup: tup[1], reverse=True)
    return results

#print (get_best_yellows (filtered_set)[:10])

# By green score
def get_best_greens (corpus):
    all_word_probs = get_all_word_probs (corpus)
    all_word_probs.sort (key=lambda tup: tup[1], reverse=True)
    return all_word_probs
    #return ([ elem for (elem, score) in all_word_probs[:n] ])

#print (get_best_greens (100, filtered_set))

def get_wordle_scores (word, corpus):
    green_score = 0
    yellow_score = 0
    for checkWord in corpus:
        for c1, c2 in zip (word, checkWord):
            if c1 == c2:
                green_score += 1
            elif c1 in checkWord:
                yellow_score += 1
    green_score /= len (corpus)
    yellow_score /= len (corpus)
    return (green_score, yellow_score)

print (get_wordle_scores ("soree", filtered_set))

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



def play_game (corpus):
    os.system("clear -x")
    print ("Play Wordle:")
    print ("There are {0} possible words".format (len(corpus)))
    best_green_guesses = get_best_greens (corpus)
    best_yellow_guesses = get_best_yellows (corpus)
    sorted_yellows = sort_yellow_guesses_by_green (best_yellow_guesses, best_green_guesses)

    print ("Here are my ten best guesses from best to worst, by green priority:")
    for elem in best_green_guesses[:10]:
        print(elem)
    print ("Here are my ten best guesses from best to worst, by yellow priority:")
    for elem in sorted_yellows[:10]:
        print(elem)
    print ("Enter one of them into wordle then write the word here. Or \"quit\" to quit.")
    guess = input()
    if guess != "quit":
        print ("Now tell me how well the word did. Write something like \"gyfff\", where an f indicates grey, y yellow and g green:")
        colours = list (input ())
        newCorpus = filter_corpus_by_guess (guess, colours, corpus)
        play_game (newCorpus)

print("hairs" in filtered_set)
play_game (filtered_set)

#print (len (words.words()))

# Waaaay too slow
def get_all_wordle_scores (corpus):
    return dict ([ (word, get_wordle_scores (word, corpus)) for word in corpus ])
#print (get_all_wordle_scores (filtered_set)["soree"])
