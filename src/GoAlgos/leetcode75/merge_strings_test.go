package lc75

import "testing"

func TestMergeAlternately(t *testing.T) {
	tests := []struct {
		name  string
		word1 string
		word2 string
		want  string
	}{
		{"LeetCode sample 1", "abc", "pqr", "apbqcr"},
		{"LeetCode sample 1", "ab", "pqrs", "apbqrs"},
		{"LeetCode sample 1", "abcd", "pq", "apbqcd"},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			got := mergeAlternately(tt.word1, tt.word2)
			if got != tt.want {
				t.Fatalf("mergeAlternately(%v, %v) = %v; want %v", tt.word1, tt.word2, got, tt.want)
			}
		})
	}
}
