import auto_test_tools as att


'''

Write a function that takes as input a list which is used as
a mask of N elements with values 0 or 1. The function should
then compute the integer output defined by

     x = \sum_{i=1}^N  2^{i-1} mask(i)

Use a loop for computing the output value.

Test your procedure on each of the input examples below

  mask := <0 0 0 0>;
  mask := <0 0 0 1>;
  mask := <0 0 1 0>;
  mask := <0 0 1 1>;
  mask := <0 1 0 0>;
  mask := <0 1 0 1>;
  mask := <0 1 1 0>;
  mask := <0 1 1 1>;
  mask := <1 0 0 0>;

The notation <...> is a bit-pattern with least significant
bit at the left-most position and most significant bit
at the right-most position.

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''


def make_number(mask: list) -> int:
    total = 0
    for i in range(len(mask)):
        total += mask[i] * 2**(i)
    """
    Generate a number from a given bit mask.

    :param mask:    The bit mask gives as a list with least significant bit first and most significant bit last.

    :return:        The decimal number corresponding ot the binary bit mask.
    """
    return total


att.start()
att.begin_task('Task 1')

mask_0 = [0, 0, 0, 0]
mask_1 = [1, 0, 0, 0]
mask_2 = [0, 1, 0, 0]
mask_3 = [1, 1, 0, 0]
mask_4 = [0, 0, 1, 0]
mask_5 = [1, 0, 1, 0]
mask_6 = [0, 1, 1, 0]
mask_7 = [1, 1, 1, 0]
mask_8 = [0, 0, 0, 1]
mask_9 = [1, 0, 0, 1]
mask_10 = [0, 1, 0, 1]
mask_11 = [1, 1, 0, 1]
mask_12 = [0, 0, 1, 1]
mask_13 = [1, 0, 1, 1]
mask_14 = [0, 1, 1, 1]
mask_15 = [1, 1, 1, 1]

tst_0 = make_number(mask_0)
tst_1 = make_number(mask_1)
tst_2 = make_number(mask_2)
tst_3 = make_number(mask_3)
tst_4 = make_number(mask_4)
tst_5 = make_number(mask_5)
tst_6 = make_number(mask_6)
tst_7 = make_number(mask_7)
tst_8 = make_number(mask_8)
tst_9 = make_number(mask_9)
tst_10 = make_number(mask_10)
tst_11 = make_number(mask_11)
tst_12 = make_number(mask_12)
tst_13 = make_number(mask_13)
tst_14 = make_number(mask_14)
tst_15 = make_number(mask_15)

att.is_equal(tst_0, 0, att.get_linenumber(), ' mask 0 failed')
att.is_equal(tst_1, 1, att.get_linenumber(), ' mask 1 failed')
att.is_equal(tst_2, 2, att.get_linenumber(), ' mask 2 failed')
att.is_equal(tst_3, 3, att.get_linenumber(), ' mask 3 failed')
att.is_equal(tst_4, 4, att.get_linenumber(), ' mask 4 failed')
att.is_equal(tst_5, 5, att.get_linenumber(), ' mask 5 failed')
att.is_equal(tst_6, 6, att.get_linenumber(), ' mask 6 failed')
att.is_equal(tst_7, 7, att.get_linenumber(), ' mask 7 failed')
att.is_equal(tst_8, 8, att.get_linenumber(), ' mask 8 failed')
att.is_equal(tst_9, 9, att.get_linenumber(), ' mask 9 failed')
att.is_equal(tst_10, 10, att.get_linenumber(), ' mask 10 failed')
att.is_equal(tst_11, 11, att.get_linenumber(), ' mask 11 failed')
att.is_equal(tst_12, 12, att.get_linenumber(), ' mask 12 failed')
att.is_equal(tst_13, 13, att.get_linenumber(), ' mask 13 failed')
att.is_equal(tst_14, 14, att.get_linenumber(), ' mask 14 failed')
att.is_equal(tst_15, 15, att.get_linenumber(), ' mask 15 failed')

att.end_task()

att.stop()
