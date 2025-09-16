package godailies

func canBeTypedWords(text string, brokenLetters string) int {
	var seen [26]bool
	for _, r := range brokenLetters {
		if 'a' <= r && r <= 'z' {
			seen[r-'a'] = true
		}
	}

	skip := false
	words := 0
	for i, c := range text {
		if c != ' ' && seen[c-'a'] {
			skip = true
			continue
		}
		if c == ' ' || i == len(text)-1 {
			if !skip {
				words++
			}
			skip = false
		}
	}

	return words
}
