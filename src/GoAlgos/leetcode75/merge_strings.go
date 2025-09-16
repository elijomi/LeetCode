package lc75

import "strings"

func mergeAlternately(word1 string, word2 string) string {
	var b strings.Builder
	w1l := len(word1)
	w2l := len(word2)
	for i := 0; i < w1l; i++ {
		b.WriteByte(word1[i])
		if i < w2l {
			b.WriteByte(word2[i])
		}
	}
	if w1l == w2l {
		return b.String()
	}
	if w2l > w1l {
		start := b.Len() / 2
		b.WriteString(word2[start:]) 
	}

	return b.String()
}
