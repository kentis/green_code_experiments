import fs from "node:fs";

const filename = new URL(
  "../data/data_1k.json",
  import.meta.url,
).pathname.replaceAll("%20", " ");
const jsonString = fs.readFileSync(filename, "utf8");

const { avgTime, totalTime } = findAverageRunTime(() => JSON.parse(jsonString));

console.log(
  `Average parsing time with JSON.parse: ${avgTime.toFixed(
    6,
  )} seconds. Total ${totalTime.toFixed(6)} seconds.`,
);

function findAverageRunTime(testedFunction, repeats = 100) {
  const times = [];

  for (let i = 0; i < repeats; i++) {
    const start = performance.now();

    // RUN TEST
    testedFunction();

    const end = performance.now();

    times.push((end - start) / 1000); // seconds
  }

  const avgTime = times.reduce((a, b) => a + b, 0) / repeats;
  const totalTime = times.reduce((a, b) => a + b, 0);

  return { avgTime, totalTime };
}
