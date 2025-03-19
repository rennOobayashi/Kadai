#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main() {
	FILE *txt_file = fopen("in.txt", "r");
	FILE *out_file = fopen("out.txt", "w");
	char buffers[256];

	if (txt_file == NULL) {
		printf("Failed to load text file.\n Please make sure the file you are receiving exists in the same location as the program.\n");
		return 1;
	}

	printf("\t\tMidterm Exam Grade List\n");
	fprintf(out_file, "\t\t\t\tMidterm Exam Grade List\n");

	printf("=====================================================\n");
	fprintf(out_file, "============================================\n");

	printf("student number\t\tLanguage\tEnglish\tMath\ttotal score\taverage\n");
	fprintf(out_file, "student number\t\t\tLanguage\t\tEnglish\t\tMath\t\ttotal score\t\taverage\n");

	printf("=====================================================\n");
	fprintf(out_file, "============================================\n");


	while (fgets(buffers, sizeof(buffers), txt_file) != NULL) {
		int sum = 0;
		int cnt = 0;
		float avg = 0.0f;

		char* token;
		char* context = NULL;

		token = strtok_s(buffers, "\n", &context);
		token = strtok_s(buffers, " ", &context);

		printf("%s", token);
		fprintf(out_file, "%s", token);
		token = strtok_s(NULL, " ", &context);

		while (token != NULL) {
			printf("\t%s", token);
			fprintf(out_file, "\t\t%s", token);

			sum += atoi(token);
			cnt++;

			token = strtok_s(NULL, " ", &context);
		}

		printf("\t%d", sum);
		fprintf(out_file, "\t\t%d", sum);

		avg = (float)sum / cnt;

		printf("\t%.1f\n", avg);
		fprintf(out_file, "\t\t%.1f\n", avg);

		//fprintf(out_file, buffers);

	}

	printf("=====================================================\n");
	fprintf(out_file, "============================================\n");

	printf("\nThe above content has been saved successfully.\n");

	fclose(txt_file);
	fclose(out_file);

	return 0;
}
