package godailies

import "testing"

func TestCanBeTypedWords(t *testing.T) {
	tests := []struct {
		name   string
		s      string
		broken string
		want   int
	}{
		{"LeetCode sample 1", "hello world", "ad", 1},
		{"LeetCode sample 2", "leet code", "lt", 1},
		{"LeetCode sample 3", "leet code", "e", 0},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			got := canBeTypedWords(tt.s, tt.broken)
			if got != tt.want {
				t.Fatalf("canBeTypedWords(%q, %q) = %d; want %d", tt.s, tt.broken, got, tt.want)
			}
		})
	}
}
