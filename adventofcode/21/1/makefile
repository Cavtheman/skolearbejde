GHC=ghc

.PHONY: run clean

day%:
	@$(GHC) $@.hs -o $@.run
	@rm *.o *.hi

clean:
	@rm *.run
